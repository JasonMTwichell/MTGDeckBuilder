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

        // setup hosting directory
        string rootDirectory = _cfg.GetConfigurationValue("MTG_ROOT_DIRECTORY");        
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
        ParsedMeta? fetchedMeta = await _parser.ParseMetaData(Path.GetFileNameWithoutExtension(metaFileFullPath));           

        if(existingMeta == null || existingMeta.Version != fetchedMeta.Version)
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

public interface IMTGJsonHttpService
{
    Task GetMetaFile(string writeToPath);
    Task GetEnumValuesFile(string writeToPath);
    Task GetAllPrintingsFile(string writeToPath);
}

public class MTGJsonHttpService : IMTGJsonHttpService
{
    private readonly HttpClient _client;
    private readonly IFileTreatment _gzipDecompressor;
    public MTGJsonHttpService(HttpClient client)
    {
        _client = client;
        _gzipDecompressor = new DecompressGZipFileTreatment();
    }
    public async Task GetMetaFile(string writeToPath)
    {
        // TODO: MOVE THIS TO CONFIG
        string metaFileURI = @"https://mtgjson.com/api/v5/Meta.json.gz";
        using (Stream stream = await _client.GetStreamAsync(metaFileURI))
        using (FileStream fileStream = File.Create(writeToPath))
        {
            await stream.CopyToAsync(fileStream);
        }

        await _gzipDecompressor.TreatFile(writeToPath, Path.Combine(Path.GetDirectoryName(writeToPath), Path.GetFileNameWithoutExtension(writeToPath)));
    }

    public async Task GetEnumValuesFile(string writeToPath)
    {
        string metaFileURI = @"https://mtgjson.com/api/v5/EnumValues.json.gz";
        using (Stream stream = await _client.GetStreamAsync(metaFileURI))
        using (FileStream fileStream = File.Create(writeToPath))
        {
            await stream.CopyToAsync(fileStream);
        }

        await _gzipDecompressor.TreatFile(writeToPath, Path.Combine(Path.GetDirectoryName(writeToPath), Path.GetFileNameWithoutExtension(writeToPath)));
    }

    public async Task GetAllPrintingsFile(string writeToPath)
    {
        string metaFileURI = @"https://mtgjson.com/api/v5/AllPrintings.json.gz";
        using (Stream stream = await _client.GetStreamAsync(metaFileURI))
        using (FileStream fileStream = File.Create(writeToPath))
        {
            await stream.CopyToAsync(fileStream);
        }

        await _gzipDecompressor.TreatFile(writeToPath, Path.Combine(Path.GetDirectoryName(writeToPath), Path.GetFileNameWithoutExtension(writeToPath)));

        IFileTreatment splitSetsTreatment = new MTGJsonAllPrintingsSplitSetsFileTreatment();
        await splitSetsTreatment.TreatFile(Path.Combine(Path.GetDirectoryName(writeToPath), Path.GetFileNameWithoutExtension(writeToPath)), null);
    }
}

