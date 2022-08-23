using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.Services.JSONParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonParser : IMTGParser
    {
        public async Task<DataFile> ParseMTGFile(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                MTGJsonFile jsonFile = serializer.Deserialize<MTGJsonFile>(jsonReader);
                DataFile dataFile = new DataFile()
                {
                    VersionNumber = jsonFile.Meta.Version,
                    VersionDate = jsonFile.Meta.Date,
                    Sets = jsonFile.Sets.Select(kvp => kvp.Value).Select(set => new Set()
                    {
                        SetName = set.SetName,
                        SetCode = set.SetCode,
                        SetType = set.SetType,
                        BaseSetSize = set.BaseSetSize,
                        TotalSetSize = set.TotalSetSize,
                        ReleaseDate = set.ReleaseDate,
                        SetCards = set.SetCards.Select(c => new Card()
                        {
                            UUID = c.UUID,
                            AsciiName = c.AsciiName,
                            Name = c.Name,
                            Text = c.Text,
                            Type = c.Type,
                            Layout = c.Layout,
                            Side = c.Side,
                            ManaCost = c.ManaCost,
                            ManaValue = c.ManaValue,
                            Loyalty = c.Loyalty,
                            HandModifier = c.HandModifier,
                            LifeModifier = c.LifeModifier,
                            Power = c.Power,
                            Toughness = c.Toughness,
                            Printings = c.Printings ?? Array.Empty<string>(),
                            Keywords = c.Keywords ?? Array.Empty<string>(),
                            Types = c.Types ?? Array.Empty<string>(),
                            SuperTypes = c.SuperTypes ?? Array.Empty<string>(),
                            SubTypes = c.SubTypes ?? Array.Empty<string>(),
                            ColorIdentities = c.ColorIdentity ?? Array.Empty<string>(),
                            Colors = c.Colors ?? Array.Empty<string>(),
                            IsFunny = c.IsFunny,
                            IsReserved = c.IsReserved,
                            HasAlternateDeckLimit = c.HasAlternateDeckLimit,
                            FaceName = c.FaceName,
                            FlavorText = c.FlavorText,
                            NumberInSet = c.NumberInSet,
                            Rarity = c.Rarity,
                            SetCode = c.SetCode,
                            Rulings = c.Rulings?.Select(r => new Ruling()
                            {
                                RulingDate = r.RulingDate,
                                RulingText = r.RulingText
                            }).ToArray() ?? Array.Empty<Ruling>(),
                            Formats = c.Formats?.Select(f => new Format()
                            {
                                FormatName = f.Key,
                                Status = f.Value
                            }).ToArray() ?? Array.Empty<Format>(),
                            PurchaseInformation = c.PurchaseInformation?.Select(pi => new PurchaseInformation()
                            {
                                StoreFrontName = pi.Key,
                                CardURI = pi.Value
                            }).ToArray() ?? Array.Empty<PurchaseInformation>(),
                        }).ToArray(),
                    }).ToArray(),
                };

                return dataFile;
            }
        }
    }
}
