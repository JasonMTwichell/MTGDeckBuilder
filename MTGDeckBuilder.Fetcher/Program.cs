using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.Fetcher;
using MTGDeckBuilder.MTGJson;
using MTGDeckBuilder.MTGJson.DTO;
using System.IO;
using Unity;

class Program
{
    private static IUnityContainer _container;
    private static IMTGConfiguration _cfg;
    private static IMTGJsonParser _parser;
    private static IMTGJsonHttpService _httpSvc;
    static async Task Main(string[] args)
    {
        _container = IoCBootstrapper.BootstrapIoC();
        _cfg = _container.Resolve<IMTGConfiguration>();
        _parser = _container.Resolve<IMTGJsonParser>();
        _httpSvc = _container.Resolve<IMTGJsonHttpService>();

        //await FetchCards();
        await FetchImages();
    }

    private async static Task FetchCards()
    {
        // setup hosting directory
        string rootDirectory = _cfg.GetConfigurationValue("MTG_ROOTDIR_PATH");
        if (!Directory.Exists(rootDirectory))
        {
            Directory.CreateDirectory(rootDirectory);
        }

        // setup staging directory
        string stagingDirectory = Path.Combine(rootDirectory, "STAGING");
        if (!Directory.Exists(stagingDirectory))
        {
            Directory.CreateDirectory(stagingDirectory);
        }

        string existingMetaPath = Path.Combine(rootDirectory, string.Format("{0}.json", _cfg.GetConfigurationValue("META_FILENAME")));
        ParsedMeta? existingMeta = null;
        if (File.Exists(existingMetaPath))
        {
            existingMeta = await _parser.ParseMetaData(existingMetaPath);
        }

        // fetch into staging to keep files consistent
        string metaFileFullPath = Path.Combine(stagingDirectory, string.Format("{0}.json.gz", _cfg.GetConfigurationValue("META_FILENAME")));
        await _httpSvc.GetMetaFile(metaFileFullPath);

        string unzippedMetaFilePath = Path.GetFileNameWithoutExtension(metaFileFullPath);
        ParsedMeta? fetchedMeta = await _parser.ParseMetaData(Path.Combine(stagingDirectory, unzippedMetaFilePath));

        if (existingMeta == null || existingMeta.Version != fetchedMeta.Version)
        {
            string enumsFileFullPath = Path.Combine(stagingDirectory, string.Format("{0}.json.gz", _cfg.GetConfigurationValue("ENUMVALUES_FILENAME")));
            string allPrintingsFullPath = Path.Combine(stagingDirectory, string.Format("{0}.json.gz", _cfg.GetConfigurationValue("ALLPRINTINGS_FILENAME")));
            await _httpSvc.GetEnumValuesFile(enumsFileFullPath);
            await _httpSvc.GetAllPrintingsFile(allPrintingsFullPath);

            // fetch successful copy to root
            await CopyDirectory(stagingDirectory, rootDirectory);
        }

        Directory.Delete(stagingDirectory, true);
    }

    private async static Task FetchImages()
    {
        string imagesDir = _cfg.GetConfigurationValue("IMG_ROOTDIR_PATH");
        if(!Directory.Exists(imagesDir))
        {
            Directory.CreateDirectory(imagesDir);
        }

        string mtgRootDir = _cfg.GetConfigurationValue("MTG_ROOTDIR_PATH");
        string setDir = Path.Combine(mtgRootDir, "SETS");
        foreach(string setFile in Directory.GetFiles(setDir))
        {
            ParsedAllPrintingsSet parsedSet = await _parser.ParseSet(setFile);
            string[] allScryfallIds = parsedSet.Cards.Select(card => card.Identifiers?.ScryfallId)?.ToArray();

            // check for set directory in images directory
            string setImagesDir = Path.Combine(imagesDir, parsedSet.Code);
            if(!Directory.Exists(setImagesDir))
            {
                Directory.CreateDirectory(setImagesDir);
            }

            // check for scryfallid in setdirectory
            string[] fetchedScryfallImageIds = Directory.EnumerateFiles(setImagesDir).Select(filePath => Path.GetFileNameWithoutExtension(filePath)).ToArray();
            string[] unfetchedScryfallIds = allScryfallIds.Except(fetchedScryfallImageIds).ToArray();
            // if not exists, pull it into set directory
            foreach(string unfetchedScryfallId in unfetchedScryfallIds)
            {
                string writeToPath = Path.Combine(setImagesDir, string.Format("{0}.jpg", unfetchedScryfallId));
                await _httpSvc.GetScryfallImage(writeToPath, unfetchedScryfallId, false);
            }
        }
    }

    private static Task CopyDirectory(string sourceDir, string destDir)
    {
        foreach(string fileName in Directory.GetFiles(sourceDir, "*.json"))
        {
            string moveToPath = Path.Combine(destDir, Path.GetFileName(fileName));
            File.Copy(fileName, moveToPath, true);
        }

        string setsStagingDirectoryPath = Directory.GetDirectories(sourceDir).First();
        string setsRootDirectory = Path.Combine(destDir, "SETS");
        if(Directory.Exists(setsRootDirectory))
        {
            Directory.Delete(setsRootDirectory, true);
        }

        Directory.Move(setsStagingDirectoryPath, setsRootDirectory);

        return Task.CompletedTask;
    }
}