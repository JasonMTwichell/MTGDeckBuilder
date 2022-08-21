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
            DataFile dataFile = await parser.ParseMTGFile(@"C:\Users\jason\Downloads\MTG JSON\AtomicCards\AtomicCards.json");

            // get all reference data
            ColorData[] distinctColors = dataFile.Cards.SelectMany(c => c.Colors).Distinct().Select(c => new ColorData()
            {
                ColorName = c
            }).ToArray();

            ColorIdentityData[] distinctColorIdentities = dataFile.Cards.SelectMany(c => c.ColorIdentity).Distinct().Select(c => new ColorIdentityData()
            {
                ColorIdentityName = c
            }).ToArray();

            TypeData[] distinctTypes = dataFile.Cards.SelectMany(c => c.Types).Distinct().Select(t => new TypeData()
            {
                TypeName = t
            }).ToArray();

            SuperTypeData[] distinctSuperTypes = dataFile.Cards.SelectMany(c => c.SuperTypes).Distinct().Select(t => new SuperTypeData()
            {
                SuperTypeName = t
            }).ToArray();

            SubTypeData[] distinctSubTypes = dataFile.Cards.SelectMany(c => c.Types).Distinct().Select(t => new SubTypeData()
            {
                SubTypeName = t
            }).ToArray();

            KeywordData[] distinctKeywords = dataFile.Cards.SelectMany(c => c.Keywords).Distinct().Select(k => new KeywordData()
            {
                Keyword = k
            }).ToArray();

            LegalityData[] distinctLegalities = dataFile.Cards.SelectMany(c => c.Legalities).Select(p => p.Format).Distinct().Select(p => new LegalityData()
            {
                Format = p,
            }).ToArray();

            CardData[] cards = dataFile.Cards.Select(c => new CardData()
            {
                Name = c.Name,
                AsciiName = c.AsciiName,
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
                IsFunny = c.IsFunny,
                IsReserved = c.IsReserved,
                HasAlternateDeckLimit = c.HasAlternateDeckLimit,
                CardColors = c.Colors?.Join(distinctColors, o => o, i => i.ColorName, (o, i) => new CardColorData()
                {
                    Color = i
                }).ToArray(),
                CardColorIdentities = c.ColorIdentity?.Join(distinctColorIdentities, o => o, i => i.ColorIdentityName, (o, i) => new CardColorIdentityData()
                {
                    ColorIdentity = i
                }).ToArray(),
                CardTypes = c.Types?.Join(distinctTypes, o => o, i => i.TypeName, (o, i) => new CardTypeData()
                {
                    Type = i
                }).ToArray(),
                CardSuperTypes = c.SuperTypes?.Join(distinctSuperTypes, o => o, i => i.SuperTypeName, (o, i) => new CardSuperTypeData()
                {
                    SuperType = i
                }).ToArray(),
                CardSubTypes = c.SubTypes?.Join(distinctSubTypes, o => o, i => i.SubTypeName, (o, i) => new CardSubTypeData()
                {
                    SubType = i
                }).ToArray(),
                CardKeywords = c.Keywords?.Join(distinctKeywords, o => o, i => i.Keyword, (o, i) => new CardKeywordData()
                {
                    Keyword = i
                }).ToArray(),
                CardLegalities = c.Legalities?.Join(distinctLegalities, o => o.Format, i => i.Format, (o, i) => new CardLegalityData()
                {
                    Legality = i,
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
                Cards = cards,
                Legalities = distinctLegalities,
            };

            using (MTGDeckBuilderContext ctx = new MTGDeckBuilderContext("MTGDeckBuilder.db"))
            {
                IMTGDeckBuilderRepository repo = new MTGDeckBuilderRepository(ctx);
                await repo.BootstrapDB(bootstrapData);
            }
        }
    }
}
