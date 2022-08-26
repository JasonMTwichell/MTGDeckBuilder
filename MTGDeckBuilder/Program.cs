using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.DbUp;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using MTGDeckBuilder.Services;
using MTGDeckBuilder.Services.JSONParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGDeckBuilder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: Move this to configuration
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts("MTGDeckBuilder.db");

            // TODO: Move this to configuration
            IMTGParser parser = new MTGJsonParser();
            DataFile dataFile = await parser.ParseMTGFile(@"C:\Users\jason\Downloads\MTG JSON\AllPrintings.json");

            // get all reference data
            Card[] allCards = dataFile.Sets.SelectMany(s => s.SetCards).ToArray();
            ColorData[] distinctColors = allCards.SelectMany(c => c.Colors).Distinct().Select(c => new ColorData()
            {
                Color = c
            }).ToArray();

            ColorIdentityData[] distinctColorIdentities = allCards.SelectMany(c => c.ColorIdentities).Distinct().Select(c => new ColorIdentityData()
            {
                ColorIdentity = c
            }).ToArray();

            TypeData[] distinctTypes = allCards.SelectMany(c => c.Types).Distinct().Select(t => new TypeData()
            {
                Type = t
            }).ToArray();

            SuperTypeData[] distinctSuperTypes = allCards.SelectMany(c => c.SuperTypes).Distinct().Select(t => new SuperTypeData()
            {
                SuperType = t
            }).ToArray();

            SubTypeData[] distinctSubTypes = allCards.SelectMany(c => c.Types).Distinct().Select(t => new SubTypeData()
            {
                SubType = t
            }).ToArray();

            KeywordData[] distinctKeywords = allCards.SelectMany(c => c.Keywords).Distinct().Select(k => new KeywordData()
            {
                Keyword = k
            }).ToArray();

            FormatData[] distinctLegalities = allCards.SelectMany(c => c.Formats).Select(p => p.FormatName).Distinct().Select(p => new FormatData()
            {
                Format = p,
            }).ToArray();

            SetData[] distinctSets = dataFile.Sets.Select(set => new SetData()
            {
                SetName = set.SetName,
                SetCode = set.SetCode,
                SetType = set.SetType,
                ReleaseDate = DateTime.Parse(set.ReleaseDate),
                BaseSetSize = set.BaseSetSize,
                TotalSetSize = set.TotalSetSize,
            }).Distinct().ToArray();

            CardData[] cards = allCards.Join(distinctSets, c => c.SetCode, s => s.SetCode, (c, s) => new CardData()
            {
                Set = s,
                UUID = c.UUID,
                FaceName = c.FaceName,
                FlavorText = c.FlavorText,
                NumberInSet = int.TryParse(c.NumberInSet, out int numInSet) ? numInSet : null,
                Rarity = c.Rarity,
                Name = c.Name,
                AsciiName = c.AsciiName,
                Text = c.Text,
                Type = c.Type,
                Layout = c.Layout,
                Side = c.Side,
                ManaCost = c.ManaCost,
                ManaValue = c.ManaValue,
                Loyalty = int.TryParse(c.Loyalty, out int loyalty) ? loyalty : null,
                HandModifier = c.HandModifier,
                LifeModifier = c.LifeModifier,
                Power = int.TryParse(c.Power, out int power) ? power : null,
                Toughness = int.TryParse(c.Toughness, out int toughness) ? toughness : null,
                IsFunny = c.IsFunny,
                IsReserved = c.IsReserved,
                HasAlternateDeckLimit = c.HasAlternateDeckLimit,
                CardColors = c.Colors?.Join(distinctColors, o => o, i => i.Color, (o, i) => new CardColorData()
                {
                    Color = i
                }).ToArray(),
                CardColorIdentities = c.ColorIdentities?.Join(distinctColorIdentities, o => o, i => i.ColorIdentity, (o, i) => new CardColorIdentityData()
                {
                    ColorIdentity = i
                }).ToArray(),
                CardTypes = c.Types?.Join(distinctTypes, o => o, i => i.Type, (o, i) => new CardTypeData()
                {
                    Type = i
                }).ToArray(),
                CardSuperTypes = c.SuperTypes?.Join(distinctSuperTypes, o => o, i => i.SuperType, (o, i) => new CardSuperTypeData()
                {
                    SuperType = i
                }).ToArray(),
                CardSubTypes = c.SubTypes?.Join(distinctSubTypes, o => o, i => i.SubType, (o, i) => new CardSubTypeData()
                {
                    SubType = i
                }).ToArray(),
                CardKeywords = c.Keywords?.Join(distinctKeywords, o => o, i => i.Keyword, (o, i) => new CardKeywordData()
                {
                    Keyword = i
                }).ToArray(),
                CardFormats = c.Formats?.Join(distinctLegalities, o => o.FormatName, i => i.Format, (o, i) => new CardFormatData()
                {
                    Format = i,
                    IsLegal = o.Status.ToLower() == "legal",
                }).ToArray(),
                PurchaseInformation = c.PurchaseInformation?.Select(pi => new PurchaseInformationData()
                {
                    StorefrontName = pi.StoreFrontName,
                    CardURI = pi.CardURI,
                }).ToArray(),
            }).ToArray();

            BootstrapDBData bootstrapData = new BootstrapDBData()
            {
                VersionNumber = dataFile.VersionNumber,
                VersionDate = dataFile.VersionDate,
                Colors = distinctColors,
                ColorIdentities = distinctColorIdentities,
                Types = distinctTypes,
                SuperTypes = distinctSuperTypes,
                SubTypes = distinctSubTypes,
                Keywords = distinctKeywords,
                Formats = distinctLegalities,
                Sets = distinctSets,
                Cards = cards,
            };

            using (MTGDeckBuilderContext ctx = new MTGDeckBuilderContext("MTGDeckBuilder.db"))
            {
                IMTGDeckBuilderRepository repo = new MTGDeckBuilderRepository(ctx);
                await repo.BootstrapDB(bootstrapData);
            }
        }
    }
}
