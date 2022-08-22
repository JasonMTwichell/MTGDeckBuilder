﻿using MTGDeckBuilder.Core.Domain;
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
            using(StreamReader streamReader = new StreamReader(filePath))
            using(JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                MTGJsonFile jsonFile = serializer.Deserialize<MTGJsonFile>(jsonReader);
                DataFile dataFile = new DataFile()
                {
                    VersionNumber = jsonFile.Meta.Version,
                    VersionDate = jsonFile.Meta.Date,
                    Cards = jsonFile.Cards.SelectMany(v => v.Value).Select(c => new Card()
                    {
                        ScryfallOracleID = c.Identifiers.FirstOrDefault(kvp => kvp.Key == "scryfallOracleId" || kvp.Key == "scryfallId").Value, // TODO: this makes it possible to just truncate the db entirely without effecting user data, but do these change?
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
                        Rulings = c.Rulings?.Select(r => new Ruling()
                        {
                            RulingDate = r.RulingDate,
                            RulingText = r.RulingText
                        }).ToArray() ?? Array.Empty<Ruling>(),
                        Legalities = c.Legalities?.Select(l => new Legality()
                        {
                            Format = l.Key,
                            Status = l.Value
                        }).ToArray() ?? Array.Empty<Legality>(),
                        PurchaseInformation = c.PurchaseInformation?.Select(pi => new PurchaseInformation()
                        {
                            StoreFrontName = pi.Key,
                            CardURI = pi.Value
                        }).ToArray() ?? Array.Empty<PurchaseInformation>(),
                    }).ToArray()
                };

                return dataFile;
            }
        }
    }
}
