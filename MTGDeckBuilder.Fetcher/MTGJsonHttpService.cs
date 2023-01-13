using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.MTGJson;

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

