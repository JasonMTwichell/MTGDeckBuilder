using MTGDeckBuilder.MTGJson.DTO;

namespace MTGDeckBuilder.MTGJson
{
    public interface IMTGJsonParser
    {
        Task<ParsedAllPrintingsFile> ParseAllPrintingsFile(string filePath);
    }
}
