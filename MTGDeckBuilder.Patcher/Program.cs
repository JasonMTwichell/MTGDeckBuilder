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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace MTGDeckBuilder
{
    class Program
    {
        private static IUnityContainer _container;
        private static IMTGConfiguration _cfg;
        private static IMTGDeckBuilderDbPatcher _patcher;
        private static IMTGJsonParser _parser;
        static async Task Main(string[] args)
        {
            _container = IoCBootstrapper.BootstrapIoC();
            _cfg = _container.Resolve<IMTGConfiguration>();
            _patcher = _container.Resolve<IMTGDeckBuilderDbPatcher>();
            _parser = _container.Resolve<IMTGJsonParser>();
            
            // build out pathing strings
            string rootDirectoryPath = _cfg.GetConfigurationValue("MTG_ROOTDIR_PATH");
            string dbPath = Path.Combine(rootDirectoryPath, _cfg.GetConfigurationValue("DB_FILENAME"));
            string metaFilePath = Path.Combine(rootDirectoryPath, _cfg.GetConfigurationValue("META_FILENAME"));
            string enumValuesFilePath = Path.Combine(rootDirectoryPath, _cfg.GetConfigurationValue("ENUMVALUES_FILENAME"));
            string setsDirectory = Path.Combine(rootDirectoryPath, "SETS");
            string setImagesRootDirectory = _cfg.GetConfigurationValue("IMG_ROOTDIR_PATH");

            // run dbup scripts
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts(dbPath);

            // parse and check meta
            string mtgJsonMetaFilePath = _cfg.GetConfigurationValue("MTG_JSON_META_FILEPATH");
            ParsedMeta parsedMeta = await _parser.ParseMetaData(mtgJsonMetaFilePath);
            Meta latestAppliedMeta = _patcher.GetLatestMeta();
            
            if(latestAppliedMeta == null || parsedMeta.Date > latestAppliedMeta.MetaDate)
            {
                // patch reference data
                await PatchReferenceData();

                // get all reference data
                PatchReferenceData refData = await _patcher.GetReferenceData();
                
                // patch sets
                string mtgJsonSetsPath = _cfg.GetConfigurationValue("MTG_JSON_ENUMVALUES_FILEPATH");
                IEnumerable<string> setFilePaths = Directory.EnumerateFiles(setsDirectory);

                foreach(string setFilePath in setFilePaths)
                {
                    ParsedAllPrintingsSet parsedSet = await _parser.ParseSet(setFilePath);
                    Set domainSet = new Set()
                    {
                        BaseSetSize = parsedSet.BaseSetSize,
                        Block = parsedSet.Block,
                        CardsphereSetId = parsedSet.CardsphereSetId,
                        Code = parsedSet.Code,
                        IsFoilOnly = parsedSet.IsFoilOnly,
                        IsNonFoilOnly = parsedSet.IsNonFoilOnly,
                        IsOnlineOnly = parsedSet.IsOnlineOnly,
                        KeyruneCode = parsedSet.KeyruneCode,
                        Languages = parsedSet.Languages,
                        Name = parsedSet.Name,
                        ReleaseDate = parsedSet.ReleaseDate,
                        TcgplayerGroupId = parsedSet.TcgplayerGroupId,
                        TotalSetSize = parsedSet.TotalSetSize,
                        Type = parsedSet.Type,
                        Cards = parsedSet.Cards?.Select(parsedSetCard => new Card
                        {
                            Artist = parsedSetCard.Artist,
                            BorderColor = parsedSetCard.BorderColor,
                            ConvertedManaCost = parsedSetCard.ConvertedManaCost,
                            EdhrecRank = parsedSetCard.EdhrecRank,
                            FrameVersion = parsedSetCard.FrameVersion,
                            HasFoil = parsedSetCard.HasFoil,
                            HasNonFoil = parsedSetCard.HasNonFoil,
                            IsReprint = parsedSetCard.IsReprint,
                            Language = parsedSetCard.Language,
                            Layout = parsedSetCard.Layout,
                            ManaCost = parsedSetCard.ManaCost,
                            ManaValue = parsedSetCard.ManaValue,
                            Name = parsedSetCard.Name,
                            Number = parsedSetCard.Number,
                            OriginalText = parsedSetCard.OriginalText,
                            OriginalType = parsedSetCard.OriginalType,
                            Rarity = parsedSetCard.Rarity,
                            SetCode = parsedSetCard.SetCode,
                            Text = parsedSetCard.Text,
                            Type = parsedSetCard.Type,
                            UUID = parsedSetCard.UUID,

                            Types = parsedSetCard.Types.Select(cardType => new CardType()
                            {
                                CardTypeID = refData.CardTypes.FirstOrDefault(ct => ct.CardTypeDescription == cardType).CardTypeID,
                            }).ToArray(),
                            Supertypes = parsedSetCard.Supertypes.Select(superType => new Supertype()
                            {
                                SupertypeID = refData.Supertypes.FirstOrDefault(st => st.SupertypeDescription == superType).SupertypeID,    
                            }),
                            Subtypes = parsedSetCard.Subtypes.Select(subType => new Subtype()
                            {
                                SubtypeID = refData.Subtypes.FirstOrDefault(st => st.SubtypeDescription == subType).SubtypeID,
                            }),
                            Printings = parsedSetCard.Printings.Select(printing => new CardPrinting()
                            {
                                CardID = refData.SetTypes.FirstOrDefault(set => set.SetTypeDescription == printing).SetTypeID,
                            }),
                            Keywords = parsedSetCard.Keywords,
                            Finishes = parsedSetCard.Finishes,
                            Colors = parsedSetCard.Colors,
                            ColorIdentity = parsedSetCard.ColorIdentity,
                            BoosterTypes = parsedSetCard.BoosterTypes,
                            Availability = parsedSetCard.Availability,
                            Rulings = parsedSetCard.Rulings != null ? new IEnumerable<CardRuling>() : null,

                            ForeignData = parsedSetCard.ForeignData?.Select(parsedSetCardForeignDatum => new CardForeignData
                            {
                                FaceName = parsedSetCardForeignDatum.FaceName,
                                Language = parsedSetCardForeignDatum.Language,
                                Name = parsedSetCardForeignDatum.Name,
                                Type = parsedSetCardForeignDatum.Type,
                                FlavorText = parsedSetCardForeignDatum.FlavorText,
                                MultiverseID = parsedSetCardForeignDatum.MultiverseID,
                                Text = parsedSetCardForeignDatum.Text
                            })
                        })
                    };

                    await _patcher.PatchSet(domainSet);
                }
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        }  
        
        private static async Task PatchReferenceData()
        {
            // patch reference data
            string mtgJsonEnumValuesPath = _cfg.GetConfigurationValue("MTG_JSON_ENUMVALUES_FILEPATH");
            ParsedEnumValues parsedEnumValues = await _parser.ParseEnumValues(mtgJsonEnumValuesPath);
            await _patcher.PatchData(new PatchReferenceDataCommand
            {
                MetaData = new Meta()
                {
                    MetaDate = parsedEnumValues.Meta.Date.Value,
                    Version = parsedEnumValues.Meta.Version,
                    DateApplied = DateTime.Now,
                },
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
        }

        
    }
}
