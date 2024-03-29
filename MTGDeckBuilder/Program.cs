﻿using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.DbUp;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using MTGDeckBuilder.MTGJson;
using MTGDeckBuilder.MTGJson.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace MTGDeckBuilder
{
    class Program
    {
        private static IUnityContainer _container;
        private static IMTGDeckBuilderRepository _repo;
        private static IMTGConfiguration _cfg;        
        static async Task Main(string[] args)
        {
            _container = IoCBootstrapper.BootstrapIoC();
            _repo = _container.Resolve<IMTGDeckBuilderRepository>();
            _cfg = _container.Resolve<IMTGConfiguration>();
            
            string dbPath = _cfg.GetConfigurationValue("MTG_DB_PATH");
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts(dbPath);            
            
            IMTGJsonParser parser = new MTGJsonParser();
            string mtgJsonFilePath = _cfg.GetConfigurationValue("MTG_JSON_FILE_PATH");
            ParsedAllPrintingsFile allPrintingsFile = await parser.ParseAllPrintingsFile(mtgJsonFilePath);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            // get all reference data
            ColorData[] distinctColors = _repo.GetColors().ToArray();
            ColorIdentityData[] distinctColorIdentities = _repo.GetColorIdentities().ToArray();

            // build out db based on whats here
            ParsedCard[] allCards = allPrintingsFile.Sets.SelectMany(s => s.SetCards).ToArray();
            TypeData[] distinctTypes = allCards.SelectMany(c => c.Types).Distinct().Select(t => new TypeData()
            {
                Type = t
            }).ToArray();

            SuperTypeData[] distinctSuperTypes = allCards.SelectMany(c => c.SuperTypes).Distinct().Select(t => new SuperTypeData()
            {
                SuperType = t
            }).ToArray();

            SubTypeData[] distinctSubTypes = allCards.SelectMany(c => c.SubTypes).Distinct().Select(t => new SubTypeData()
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

            SetData[] distinctSets = allPrintingsFile.Sets.Select(set => new SetData()
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
                NumberInSet = c.NumberInSet,
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
                Power = c.Power,
                Toughness = c.Toughness,
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

            // convert formats to title case
            foreach(FormatData fd in distinctLegalities)
            {
                fd.Format = textInfo.ToTitleCase(fd.Format);
            }

            BootstrapDBData bootstrapData = new BootstrapDBData()
            {
                VersionNumber = allPrintingsFile.VersionNumber,
                VersionDate = allPrintingsFile.VersionDate,
                Types = distinctTypes,
                SuperTypes = distinctSuperTypes,
                SubTypes = distinctSubTypes,
                Keywords = distinctKeywords,
                Formats = distinctLegalities,
                Sets = distinctSets,
                Cards = cards,
            };

            await _repo.BootstrapDB(bootstrapData);
        }        
    }
}
