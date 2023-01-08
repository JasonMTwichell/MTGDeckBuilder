using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.MTGJson.EnumValues;
using MTGDeckBuilder.MTGJson.AllPrintings;
using Newtonsoft.Json;
using MTGDeckBuilder.MTGJson.Mapping;
using MTGDeckBuilder.MTGJson.Meta;

namespace MTGDeckBuilder.MTGJson
{
    public partial class MTGJsonParser : IMTGJsonParser
    {
        public Task<ParsedEnumValues> ParseEnumValues(string enumFilePath)
        {
            using (StreamReader streamReader = new StreamReader(enumFilePath))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                MTGJsonEnumValues? deserializedEnumValues = serializer.Deserialize<MTGJsonEnumValues>(jsonReader);
                ParsedEnumValues parsedEnumValues = EnumValuesMapper.MapToParsedEnumValues(deserializedEnumValues);
                return Task.FromResult(parsedEnumValues);
            }
        }

        public Task<ParsedMeta> ParseMetaData(string metaDataFilePath)
        {
            using (StreamReader streamReader = new StreamReader(metaDataFilePath))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                MTGJsonMeta? deserializedMeta = serializer.Deserialize<MTGJsonMeta>(jsonReader);
                ParsedMeta parsedMeta = MetaMapper.MapToParsedMeta(deserializedMeta);
                return Task.FromResult(parsedMeta);
            }
        }

        public Task<ParsedAllPrintingsSet> ParseSets(string setFilePath)
        {
            using (StreamReader streamReader = new StreamReader(setFilePath))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                MTGJsonAllPrintingsSet? deserializedSet = serializer.Deserialize<MTGJsonAllPrintingsSet>(jsonReader);
                ParsedAllPrintingsSet parsedSet = AllPrintingsMapper.MapToParsedAllPrintingsSet(deserializedSet);
                return Task.FromResult(parsedSet);
            }
        }
    }
}
