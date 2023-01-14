using MTGDeckBuilder.MTGJson.DTO;

namespace MTGDeckBuilder.MTGJson
{
    public interface IMTGJsonParser
    {
        Task<ParsedAllPrintingsSet> ParseSet(string setsDirectoryPath);
        Task<ParsedEnumValues> ParseEnumValues(string enumFilePath);
        Task<ParsedMeta> ParseMetaData(string metaDataFilePath);
    }
}
