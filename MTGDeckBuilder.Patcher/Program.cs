using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.DbUp;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using MTGDeckBuilder.MTGJson;
using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.Patcher;
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
        private static IMTGDeckBuilderDbPatcher _patcher;
        static async Task Main(string[] args)
        {
            _container = IoCBootstrapper.BootstrapIoC();
            //_repo = _container.Resolve<IMTGDeckBuilderRepository>();
            _cfg = _container.Resolve<IMTGConfiguration>();
            _patcher = _container.Resolve<IMTGDeckBuilderDbPatcher>();
            
            // run dbup scripts
            string dbPath = _cfg.GetConfigurationValue("MTG_DB_PATH");
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts(dbPath);            
            
            // patch reference data
            IMTGJsonParser parser = new MTGJsonParser();
            string mtgJsonEnumValuesPath = _cfg.GetConfigurationValue("MTG_JSON_ENUMVALUES_FILEPATH");
            ParsedEnumValues parsedEnumValues = await parser.ParseEnumValues(mtgJsonEnumValuesPath);
            await _patcher.PatchReferenceData(new PatchReferenceDataCommand
            {
                Availabilities = parsedEnumValues.Data.CardEnumValues.Availabilities.Select(a => new Availability
                {
                    AvailabilityDescription = a 
                }).ToArray(),
                BoosterTypes = parsedEnumValues.Data.CardEnumValues.BoosterTypes.Select(bt => new BoosterType()
                {
                    BoosterTypeDescription = bt
                }).ToArray(),
                BorderColors = parsedEnumValues.Data.CardEnumValues.BorderColors.Select(bc => new BorderColor()
                {
                    BorderColorDescription = bc
                }).ToArray(),
                CardTypes = parsedEnumValues.Data.CardEnumValues.Types.Select(ct => new CardType()
                {
                    CardTypeDescription = ct
                }).ToArray(),
                Colors = parsedEnumValues.Data.CardEnumValues.Colors.Select(c => new Color()
                {
                    ColorDescription = c
                }).ToArray(),
                ColorIdentities = parsedEnumValues.Data.CardEnumValues.ColorIdentities.Select(ci => new ColorIdentity()
                {
                    ColorIdentityDescription = ci
                }).ToArray(),
                ColorIndicators = parsedEnumValues.Data.CardEnumValues.ColorIndicators.Select(ci => new ColorIndicator()
                {
                    ColorIndicatorDescription = ci
                }).ToArray(),
                DeckTypes = parsedEnumValues.Data.DeckEnumValues.Types.Select(dt => new DeckType()
                {
                    DeckTypeDescription = dt
                }).ToArray(),
                DuelDecks = parsedEnumValues.Data.CardEnumValues.DuelDecks.Select(dd => new DuelDeck()
                {
                    DuelDeckDescription = dd
                }).ToArray(),
                Finishes = parsedEnumValues.Data.CardEnumValues.Finishes.Select(f => new Finish()
                {
                    FinishDescription = f
                }).ToArray(),
                ForeignDataLanguages = parsedEnumValues.Data.ForeignDataEnumValues.Languages.Select(fdl => new ForeignDataLanguage()
                {
                    ForeignDataLanguageDescription = fdl
                }).ToArray(),
                FrameEffects = parsedEnumValues.Data.CardEnumValues.FrameEffects.Select(fe => new FrameEffect()
                {
                    FrameEffectDescription = fe
                }).ToArray(),
                FrameVersions = parsedEnumValues.Data.CardEnumValues.FrameVersions.Select(fv => new FrameVersion()
                {
                    FrameVersionDescription = fv
                }).ToArray(),
                Keywords = parsedEnumValues.Data.KeywordEnumValues.AbilityWords.Select(kw => new Keyword()
                {
                    fkKeywordType = 1,
                    KeywordDescription = kw
                })
                .Concat(parsedEnumValues.Data.KeywordEnumValues.KeywordAbilities.Select(kw => new Keyword()
                {
                    fkKeywordType = 2,
                    KeywordDescription = kw
                }))
                .Concat(parsedEnumValues.Data.KeywordEnumValues.KeywordActions.Select(kw => new Keyword()
                {
                    fkKeywordType = 3,
                    KeywordDescription = kw
                })).ToArray(),
                Languages = parsedEnumValues.Data.CardEnumValues.Languages.Select(l => new Language()
                {
                    LanguageDescription = l
                }).ToArray(),
                Layouts = parsedEnumValues.Data.CardEnumValues.Layouts.Select(l => new Layout()
                {
                    LayoutDescription = l
                }).ToArray(),
                PromoTypes = parsedEnumValues.Data.CardEnumValues.PromoTypes.Select(pt => new PromoType()
                {
                    PromoTypeDescription = pt
                }).ToArray(),
                Rarities = parsedEnumValues.Data.CardEnumValues.Rarities.Select(r => new Rarity()
                {
                    RarityDescription = r
                }).ToArray(),
                SecurityStamps = parsedEnumValues.Data.CardEnumValues.SecurityStamps.Select(ss => new SecurityStamp()
                {
                    SecurityStampDescription = ss
                }).ToArray(),
                SetTypes = parsedEnumValues.Data.SetEnumValues.Types.Select(st => new SetType()
                {
                    SetTypeDescription = st
                }).ToArray(),
                Sides = parsedEnumValues.Data.CardEnumValues.Sides.Select(s => new Side()
                {
                    SideDescription = s
                }).ToArray(),
                Subtypes = parsedEnumValues.Data.CardEnumValues.Subtypes.Select(s => new Subtype()
                {
                    SubtypeDescription = s
                }).ToArray(),
                Supertypes = parsedEnumValues.Data.CardEnumValues.Supertypes.Select(s => new Supertype()
                {
                    SupertypeDescription = s
                }).ToArray(),
                TcgPlayerSkuConditions = parsedEnumValues.Data.TcgPlayerSkuValues.Conditions.Select(tcg => new TcgPlayerSkuCondition()
                {
                    ConditionDescription = tcg
                }).ToArray(),
                TcgPlayerSkuFinishes = parsedEnumValues.Data.TcgPlayerSkuValues.Finishes.Select(tcg => new TcgPlayerSkuFinish()
                {
                    FinishDescription = tcg
                }).ToArray(),
                TcgPlayerSkuLanguages = parsedEnumValues.Data.TcgPlayerSkuValues.Languages.Select(tcg => new TcgPlayerSkuLanguage()
                {
                    LanguageDescription = tcg
                }).ToArray(),
                TcgPlayerSkuPrintings = parsedEnumValues.Data.TcgPlayerSkuValues.Printings.Select(tcg => new TcgPlayerSkuPrinting()
                {
                    PrintingDescription = tcg
                }).ToArray(),
                Watermarks = parsedEnumValues.Data.CardEnumValues.Watermarks.Select(w => new Watermark()
                {
                    WatermarkDescription = w
                }).ToArray(),
            });

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        }        
    }
}
