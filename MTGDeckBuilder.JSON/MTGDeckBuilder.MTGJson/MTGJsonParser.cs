using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.MTGJson.EnumValues;
using MTGDeckBuilder.MTGJson.AllPrintings;
using Newtonsoft.Json;
using MTGDeckBuilder.MTGJson.Mapping;

namespace MTGDeckBuilder.MTGJson
{
    public partial class MTGJsonParser : IMTGJsonParser
    {
        //public async Task<ParsedAllPrintingsFile> ParseAllPrintingsFile(string filePath)
        //{
        //    using (StreamReader streamReader = new StreamReader(filePath))
        //    using (JsonReader jsonReader = new JsonTextReader(streamReader))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        MTGJsonAllPrintingsFile jsonFile = serializer.Deserialize<MTGJsonAllPrintingsFile>(jsonReader);
        //        ParsedAllPrintingsFile dataFile = new ParsedAllPrintingsFile()
        //        {
        //            VersionNumber = jsonFile.Meta.Version,
        //            VersionDate = jsonFile.Meta.Date,
        //            Sets = jsonFile.Sets.Select(kvp => kvp.Value).Select(set => new ParsedSet()
        //            {
        //                SetName = set.SetName,
        //                SetCode = set.SetCode,
        //                SetType = set.SetType,
        //                BaseSetSize = set.BaseSetSize,
        //                TotalSetSize = set.TotalSetSize,
        //                ReleaseDate = set.ReleaseDate,
        //                SetCards = set.SetCards.Select(c => new ParsedCard()
        //                {
        //                    UUID = c.UUID,
        //                    AsciiName = c.AsciiName,
        //                    Name = c.Name,
        //                    Text = c.Text,
        //                    Type = c.Type,
        //                    Layout = c.Layout,
        //                    Side = c.Side,
        //                    ManaCost = c.ManaCost,
        //                    ManaValue = c.ManaValue,
        //                    Loyalty = c.Loyalty,
        //                    HandModifier = c.HandModifier,
        //                    LifeModifier = c.LifeModifier,
        //                    Power = c.Power,
        //                    Toughness = c.Toughness,
        //                    Printings = c.Printings ?? Array.Empty<string>(),
        //                    Keywords = c.Keywords ?? Array.Empty<string>(),
        //                    Types = c.Types ?? Array.Empty<string>(),
        //                    SuperTypes = c.SuperTypes ?? Array.Empty<string>(),
        //                    SubTypes = c.SubTypes ?? Array.Empty<string>(),
        //                    ColorIdentities = c.ColorIdentity ?? Array.Empty<string>(),
        //                    Colors = c.Colors ?? Array.Empty<string>(),
        //                    IsFunny = c.IsFunny,
        //                    IsReserved = c.IsReserved,
        //                    HasAlternateDeckLimit = c.HasAlternateDeckLimit,
        //                    FaceName = c.FaceName,
        //                    FlavorText = c.FlavorText,
        //                    NumberInSet = c.NumberInSet,
        //                    Rarity = c.Rarity,
        //                    SetCode = c.SetCode,
        //                    Rulings = c.Rulings?.Select(r => new ParsedRuling()
        //                    {
        //                        RulingDate = r.RulingDate,
        //                        RulingText = r.RulingText
        //                    }).ToArray() ?? Array.Empty<ParsedRuling>(),
        //                    Formats = c.Formats?.Select(f => new ParsedFormat()
        //                    {
        //                        FormatName = f.Key,
        //                        Status = f.Value
        //                    }).ToArray() ?? Array.Empty<ParsedFormat>(),
        //                    PurchaseInformation = c.PurchaseInformation?.Select(pi => new ParsedPurchaseInformation()
        //                    {
        //                        StoreFrontName = pi.Key,
        //                        CardURI = pi.Value
        //                    }).ToArray() ?? Array.Empty<ParsedPurchaseInformation>(),
        //                }).ToArray(),
        //            }).ToArray(),
        //        };

        //        return dataFile;
        //    }
        //}

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

        public Task<ParsedMetaData> ParseMetaData(string metaDataFilePath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParsedSet>> ParseSets(string setsDirectoryPath)
        {
            throw new NotImplementedException();
        }
    }
}
