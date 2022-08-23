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

            Card[] allCards = dataFile.Sets.SelectMany(set => set.SetCards).ToArray();

            // get all reference data
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

            LegalityData[] distinctLegalities = allCards.SelectMany(c => c.Legalities).Select(p => p.Format).Distinct().Select(p => new LegalityData()
            {
                Legality = p,
            }).ToArray();

            SetData[] sets = dataFile.Sets.Select(s => new SetData()
            {
                SetCode = s.SetCode,
                SetName = s.SetName,
                SetType = s.SetType,
                ReleaseDate = DateTime.Parse(s.ReleaseDate),
                BaseSetSize = s.BaseSetSize,
                TotalSetSize = s.TotalSetSize,
            }).ToArray();

            CardData[] cards = allCards.Select(c => new CardData()
            {
                UUID = c.UUID,
                SetCode = c.SetCode,                
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
                FaceName = c.FaceName,
                FlavorText = c.FlavorText,
                Rarity = c.Rarity,
                NumberInSet = c.NumberInSet,
                CardColors = c.Colors?.Select(color => new CardColorData()
                {
                    fkCard = c.UUID,
                    fkColor = color
                }).ToArray(),
                CardColorIdentities = c.ColorIdentities.Select(colorIdentity => new CardColorIdentityData()
                {
                    fkCard = c.UUID,
                    fkColorIdentity = colorIdentity,
                }).ToArray(),
                CardTypes = c.Types?.Select(type => new CardTypeData()
                {
                    fkCard = c.UUID,
                    fkType = type,
                }).ToArray(),
                CardSuperTypes = c.SuperTypes?.Select(superType => new CardSuperTypeData()
                {
                    fkCard = c.UUID,
                    fkSuperType = superType,
                }).ToArray(),
                CardSubTypes = c.SubTypes?.Select(subType => new CardSubTypeData()
                {
                    fkCard = c.UUID,
                    fkSubType = subType,
                }).ToArray(),
                CardKeywords = c.Keywords?.Select(keyword => new CardKeywordData()
                {
                    fkCard = c.UUID,
                    fkKeyword = keyword,
                }).ToArray(),
                CardLegalities = c.Legalities?.Select(legality => new CardLegalityData()
                {
                    fkCard = c.UUID,
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
                Legalities = distinctLegalities,
                Cards = cards,
                Sets = sets,
            };

            using (MTGDeckBuilderContext ctx = new MTGDeckBuilderContext("MTGDeckBuilder.db"))
            {
                IMTGDeckBuilderRepository repo = new MTGDeckBuilderRepository(ctx);
                await repo.BootstrapDB(bootstrapData);
            }
        }
    }
}
