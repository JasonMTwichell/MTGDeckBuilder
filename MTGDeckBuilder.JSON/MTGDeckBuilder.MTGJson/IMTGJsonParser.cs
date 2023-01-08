using MTGDeckBuilder.MTGJson.DTO;

namespace MTGDeckBuilder.MTGJson
{
    public interface IMTGJsonParser
    {
        Task<IEnumerable<ParsedSet>> ParseSets(string setsDirectoryPath);
        Task<ParsedEnums> ParseEnums(string enumFilePath);
        Task<ParsedMetaData> ParseMetaData(string metaDataFilePath);
    }
}
