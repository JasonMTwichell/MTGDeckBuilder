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
                Color = c
            }).ToArray();

            ColorIdentityData[] distinctColorIdentities = dataFile.Cards.SelectMany(c => c.ColorIdentities).Distinct().Select(c => new ColorIdentityData()
            {
                ColorIdentity = c
            }).ToArray();

            TypeData[] distinctTypes = dataFile.Cards.SelectMany(c => c.Types).Distinct().Select(t => new TypeData()
            {
                Type = t
            }).ToArray();

            SuperTypeData[] distinctSuperTypes = dataFile.Cards.SelectMany(c => c.SuperTypes).Distinct().Select(t => new SuperTypeData()
            {
                SuperType = t
            }).ToArray();

            SubTypeData[] distinctSubTypes = dataFile.Cards.SelectMany(c => c.Types).Distinct().Select(t => new SubTypeData()
            {
                SubType = t
            }).ToArray();

            KeywordData[] distinctKeywords = dataFile.Cards.SelectMany(c => c.Keywords).Distinct().Select(k => new KeywordData()
            {
                Keyword = k
            }).ToArray();

            LegalityData[] distinctLegalities = dataFile.Cards.SelectMany(c => c.Legalities).Select(p => p.Format).Distinct().Select(p => new LegalityData()
            {
                Legality = p,
            }).ToArray();

            CardData[] cards = dataFile.Cards.Select(c => new CardData()
            {
                ScryfallOracleID = c.ScryfallOracleID,
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
                CardColors = c.Colors?.Select(color => new CardColorData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkColor = color
                }).ToArray(),
                CardColorIdentities = c.ColorIdentities.Select(colorIdentity => new CardColorIdentityData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkColorIdentity = colorIdentity,
                }).ToArray(),
                CardTypes = c.Types?.Select(type => new CardTypeData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkType = type,
                }).ToArray(),
                CardSuperTypes = c.SuperTypes?.Select(superType => new CardSuperTypeData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkSuperType = superType,
                }).ToArray(),
                CardSubTypes = c.SubTypes?.Select(subType => new CardSubTypeData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkSubType = subType,
                }).ToArray(),
                CardKeywords = c.Keywords?.Select(keyword => new CardKeywordData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkKeyword = keyword,
                }).ToArray(),
                CardLegalities = c.Legalities?.Select(legality => new CardLegalityData()
                {
                    fkCard = c.ScryfallOracleID,
                    fkLegality = legality.Format,
                    IsLegal = legality.Status.ToLower() == "legal"
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
