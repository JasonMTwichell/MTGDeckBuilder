using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Patcher
{
    internal interface IMTGDeckBuilderDbPatcher
    {
        Meta GetLatestMeta();
        Task PatchData(PatchReferenceDataCommand cmd);
        Task<PatchReferenceData> GetReferenceData();
        Task PatchSet(Set set);
    }

    public class MTGDeckBuilderDbPatcherSQLite : IMTGDeckBuilderDbPatcher
    {
        private readonly MTGDeckBuilderContext _ctx;
        public MTGDeckBuilderDbPatcherSQLite(MTGDeckBuilderContext ctx)
        {
            _ctx = ctx;
        }

        public async Task PatchData(PatchReferenceDataCommand cmd)
        {
            using(var txn = _ctx.Database.BeginTransaction())
            {
                await PatchAvailabilities(cmd.Availabilities);
                await PatchBoosterTypes(cmd.BoosterTypes);
                await PatchBorderColors(cmd.BorderColors);
                await PatchCardTypes(cmd.CardTypes);
                await PatchColors(cmd.Colors);
                await PatchColorIdentities(cmd.ColorIdentities);
                await PatchDeckTypes(cmd.DeckTypes);
                await PatchDuelDecks(cmd.DuelDecks);
                await PatchFinishes(cmd.Finishes);
                await PatchForeignDataLanguages(cmd.ForeignDataLanguages);
                await PatchFrameEffects(cmd.FrameEffects);
                await PatchFrameVersions(cmd.FrameVersions);
                await PatchKeywords(cmd.Keywords);
                await PatchLanguages(cmd.Languages);
                await PatchLayouts(cmd.Layouts);
                await PatchPromoTypes(cmd.PromoTypes);
                await PatchRarities(cmd.Rarities);
                await PatchSecurityStamps(cmd.SecurityStamps);
                await PatchSetTypes(cmd.SetTypes);
                await PatchSides(cmd.Sides);
                await PatchSubtypes(cmd.Subtypes);
                await PatchSupertypes(cmd.Supertypes);
                await PatchTcgPlayerSkuConditions(cmd.TcgPlayerSkuConditions);
                await PatchTcgPlayerSkuFinishes(cmd.TcgPlayerSkuFinishes);
                await PatchTcgPlayerSkuLanguages(cmd.TcgPlayerSkuLanguages);
                await PatchTcgPlayerSkuPrintings(cmd.TcgPlayerSkuPrintings);
                await PatchWaterMarks(cmd.Watermarks);

                await AddMeta(cmd.MetaData);
                txn.Commit();
            }
        }

        private async Task PatchAvailabilities(IEnumerable<Availability> availabilities)
        {
            var inserts = availabilities.GroupJoin(
                    _ctx.Availabilities,
                    o => o.AvailabilityDescription,
                    i => i.AvailabilityDescription,
                    (o, i) => new { Availability = o, AvailabilityCount = i.Count() })
                .Where(j => j.AvailabilityCount == 0).Select(j => new AvailabilityData()
                {
                    AvailabilityDescription = j.Availability.AvailabilityDescription
                }).ToList();

            var deletes = _ctx.Availabilities
                .Where(e => !availabilities.Select(a => a.AvailabilityDescription).Contains(e.AvailabilityDescription)).ToList();

            _ctx.BulkInsert(inserts);            
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchBoosterTypes(IEnumerable<BoosterType> boosterTypes)
        {
            var inserts = boosterTypes.GroupJoin(_ctx.BoosterTypes,
                    o => o.BoosterTypeDescription,
                    i => i.BoosterTypeDescription,
                    (o, i) => new { BoosterType = o, BoosterTypeCount = i.Count() })
                .Where(j => j.BoosterTypeCount == 0).Select(j => new BoosterTypeData()
                {
                    BoosterTypeDescription = j.BoosterType.BoosterTypeDescription
                }).ToList();

            var deletes = _ctx.BoosterTypes
                .Where(e => !boosterTypes.Select(a => a.BoosterTypeDescription).Contains(e.BoosterTypeDescription))?.ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchBorderColors(IEnumerable<BorderColor> borderColors)
        {
            var inserts = borderColors.GroupJoin(_ctx.BorderColors,
                    o => o.BorderColorDescription,
                    i => i.BorderColorDescription,
                    (o, i) => new { BorderColor = o, BorderColorCount = i.Count() })
                .Where(j => j.BorderColorCount == 0).Select(j => new BorderColorData()
                {
                    BorderColorDescription = j.BorderColor.BorderColorDescription
                }).ToList();

            var deletes = _ctx.BorderColors
                .Where(e => !borderColors.Select(a => a.BorderColorDescription).Contains(e.BorderColorDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchCardTypes(IEnumerable<CardType> cardTypes)
        {
            var inserts = cardTypes.GroupJoin(_ctx.CardTypes,
                    o => o.CardTypeDescription,
                    i => i.CardTypeDescription,
                    (o, i) => new { CardType = o, CardTypeCount = i.Count() })
                .Where(j => j.CardTypeCount == 0).Select(j => new CardTypeData()
                {
                    CardTypeDescription = j.CardType.CardTypeDescription
                }).ToList();

            var deletes = _ctx.CardTypes
                .Where(e => !cardTypes.Select(a => a.CardTypeDescription).Contains(e.CardTypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchColors(IEnumerable<Color> colors)
        {
            var inserts = colors.GroupJoin(_ctx.Colors,
                    o => o.ColorDescription,
                    i => i.ColorDescription,
                    (o, i) => new { Color = o, ColorCount = i.Count() })
                .Where(j => j.ColorCount == 0).Select(j => new ColorData()
                {
                    ColorDescription = j.Color.ColorDescription
                }).ToList();

            var deletes = _ctx.Colors
                .Where(e => !colors.Select(a => a.ColorDescription).Contains(e.ColorDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchColorIdentities(IEnumerable<ColorIdentity> colorIdentitys)
        {
            var inserts = colorIdentitys.GroupJoin(_ctx.ColorIdentities,
                    o => o.ColorIdentityDescription,
                    i => i.ColorIdentityDescription,
                    (o, i) => new { ColorIdentity = o, ColorIdentityCount = i.Count() })
                .Where(j => j.ColorIdentityCount == 0).Select(j => new ColorIdentityData()
                {
                    ColorIdentityDescription = j.ColorIdentity.ColorIdentityDescription
                }).ToList();

            var deletes = _ctx.ColorIdentities
                .Where(e => !colorIdentitys.Select(a => a.ColorIdentityDescription).Contains(e.ColorIdentityDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchDeckTypes(IEnumerable<DeckType> deckTypes)
        {
            var inserts = deckTypes.GroupJoin(_ctx.DeckTypes,
                    o => o.DeckTypeDescription,
                    i => i.DeckTypeDescription,
                    (o, i) => new { DeckType = o, DeckTypeCount = i.Count() })
                .Where(j => j.DeckTypeCount == 0).Select(j => new DeckTypeData()
                {
                    DeckTypeDescription = j.DeckType.DeckTypeDescription
                }).ToList();

            var deletes = _ctx.DeckTypes
                .Where(e => !deckTypes.Select(a => a.DeckTypeDescription).Contains(e.DeckTypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchDuelDecks(IEnumerable<DuelDeck> duelDecks)
        {
            var inserts = duelDecks.GroupJoin(_ctx.DuelDecks,
                    o => o.DuelDeckDescription,
                    i => i.DuelDeckDescription,
                    (o, i) => new { DuelDeck = o, DuelDeckCount = i.Count() })
                .Where(j => j.DuelDeckCount == 0).Select(j => new DuelDeckData()
                {
                    DuelDeckDescription = j.DuelDeck.DuelDeckDescription
                }).ToList();

            var deletes = _ctx.DuelDecks
                .Where(e => !duelDecks.Select(a => a.DuelDeckDescription).Contains(e.DuelDeckDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchFinishes(IEnumerable<Finish> finishes)
        {
            var inserts = finishes.GroupJoin(_ctx.Finishes,
                    o => o.FinishDescription,
                    i => i.FinishDescription,
                    (o, i) => new { Finishe = o, FinisheCount = i.Count() })
                .Where(j => j.FinisheCount == 0).Select(j => new FinishData()
                {
                    FinishDescription = j.Finishe.FinishDescription
                }).ToList();

            var deletes = _ctx.Finishes
                .Where(e => !finishes.Select(a => a.FinishDescription).Contains(e.FinishDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchForeignDataLanguages(IEnumerable<ForeignDataLanguage> foreignLanguages)
        {
            var inserts = foreignLanguages.GroupJoin(_ctx.ForeignDataLanguages,
                    o => o.ForeignDataLanguageDescription,
                    i => i.ForeignDataLanguageDescription,
                    (o, i) => new { ForeignLanguage = o, ForeignLanguageCount = i.Count() })
                .Where(j => j.ForeignLanguageCount == 0).Select(j => new ForeignDataLanguageData()
                {
                    ForeignDataLanguageDescription = j.ForeignLanguage.ForeignDataLanguageDescription
                }).ToList();

            var deletes = _ctx.ForeignDataLanguages
                .Where(e => !foreignLanguages.Select(a => a.ForeignDataLanguageDescription).Contains(e.ForeignDataLanguageDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchFrameEffects(IEnumerable<FrameEffect> frameEffects)
        {
            var inserts = frameEffects.GroupJoin(_ctx.FrameEffects,
                    o => o.FrameEffectDescription,
                    i => i.FrameEffectDescription,
                    (o, i) => new { FrameEffect = o, FrameEffectCount = i.Count() })
                .Where(j => j.FrameEffectCount == 0).Select(j => new FrameEffectData()
                {
                    FrameEffectDescription = j.FrameEffect.FrameEffectDescription
                }).ToList();

            var deletes = _ctx.FrameEffects
                .Where(e => !frameEffects.Select(a => a.FrameEffectDescription).Contains(e.FrameEffectDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchFrameVersions(IEnumerable<FrameVersion> frameVersions)
        {
            var inserts = frameVersions.GroupJoin(_ctx.FrameVersions,
                    o => o.FrameVersionDescription,
                    i => i.FrameVersionDescription,
                    (o, i) => new { FrameVersion = o, FrameVersionCount = i.Count() })
                .Where(j => j.FrameVersionCount == 0).Select(j => new FrameVersionData()
                {
                    FrameVersionDescription = j.FrameVersion.FrameVersionDescription
                }).ToList();

            var deletes = _ctx.FrameVersions
                .Where(e => !frameVersions.Select(a => a.FrameVersionDescription).Contains(e.FrameVersionDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchKeywords(IEnumerable<Keyword> keywords)
        {
            var inserts = keywords.GroupJoin(_ctx.Keywords,
                    o => o.KeywordDescription,
                    i => i.KeywordDescription,
                    (o, i) => new { Keyword = o, KeywordCount = i.Count() })
                .Where(j => j.KeywordCount == 0).Select(j => new KeywordData()
                {
                    KeywordDescription = j.Keyword.KeywordDescription
                }).ToList();

            var deletes = _ctx.Keywords
                .Where(e => !keywords.Select(a => a.KeywordDescription).Contains(e.KeywordDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchLanguages(IEnumerable<Language> languages)
        {
            var inserts = languages.GroupJoin(_ctx.Languages,
                    o => o.LanguageDescription,
                    i => i.LanguageDescription,
                    (o, i) => new { Language = o, LanguageCount = i.Count() })
                .Where(j => j.LanguageCount == 0).Select(j => new LanguageData()
                {
                    LanguageDescription = j.Language.LanguageDescription
                }).ToList();

            var deletes = _ctx.Languages
                .Where(e => !languages.Select(a => a.LanguageDescription).Contains(e.LanguageDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchLayouts(IEnumerable<Layout> layouts)
        {
            var inserts = layouts.GroupJoin(_ctx.Layouts,
                    o => o.LayoutDescription,
                    i => i.LayoutDescription,
                    (o, i) => new { Layout = o, LayoutCount = i.Count() })
                .Where(j => j.LayoutCount == 0).Select(j => new LayoutData()
                {
                    LayoutDescription = j.Layout.LayoutDescription
                }).ToList();

            var deletes = _ctx.Layouts
                .Where(e => !layouts.Select(a => a.LayoutDescription).Contains(e.LayoutDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchPromoTypes(IEnumerable<PromoType> promoTypes)
        {
            var inserts = promoTypes.GroupJoin(_ctx.PromoTypes,
                    o => o.PromoTypeDescription,
                    i => i.PromoTypeDescription,
                    (o, i) => new { PromoType = o, PromoTypeCount = i.Count() })
                .Where(j => j.PromoTypeCount == 0).Select(j => new PromoTypeData()
                {
                    PromoTypeDescription = j.PromoType.PromoTypeDescription
                }).ToList();

            var deletes = _ctx.PromoTypes
                .Where(e => !promoTypes.Select(a => a.PromoTypeDescription).Contains(e.PromoTypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchRarities(IEnumerable<Rarity> rarities)
        {
            var inserts = rarities.GroupJoin(_ctx.Rarities,
                    o => o.RarityDescription,
                    i => i.RarityDescription,
                    (o, i) => new { Raritie = o, RaritieCount = i.Count() })
                .Where(j => j.RaritieCount == 0).Select(j => new RarityData()
                {
                    RarityDescription = j.Raritie.RarityDescription
                }).ToList();

            var deletes = _ctx.Rarities
                .Where(e => !rarities.Select(a => a.RarityDescription).Contains(e.RarityDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchSecurityStamps(IEnumerable<SecurityStamp> securityStamps)
        {
            var inserts = securityStamps.GroupJoin(_ctx.SecurityStamps,
                    o => o.SecurityStampDescription,
                    i => i.SecurityStampDescription,
                    (o, i) => new { SecurityStamp = o, SecurityStampCount = i.Count() })
                .Where(j => j.SecurityStampCount == 0).Select(j => new SecurityStampData()
                {
                    SecurityStampDescription = j.SecurityStamp.SecurityStampDescription
                }).ToList();

            var deletes = _ctx.SecurityStamps
                .Where(e => !securityStamps.Select(a => a.SecurityStampDescription).Contains(e.SecurityStampDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchSetTypes(IEnumerable<SetType> setTypes)
        {
            var inserts = setTypes.GroupJoin(_ctx.SetTypes,
                    o => o.SetTypeDescription,
                    i => i.SetTypeDescription,
                    (o, i) => new { SetType = o, SetTypeCount = i.Count() })
                .Where(j => j.SetTypeCount == 0).Select(j => new SetTypeData()
                {
                    SetTypeDescription = j.SetType.SetTypeDescription
                }).ToList();

            var deletes = _ctx.SetTypes
                .Where(e => !setTypes.Select(a => a.SetTypeDescription).Contains(e.SetTypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchSides(IEnumerable<Side> sides)
        {
            var inserts = sides.GroupJoin(_ctx.Sides,
                    o => o.SideDescription,
                    i => i.SideDescription,
                    (o, i) => new { Side = o, SideCount = i.Count() })
                .Where(j => j.SideCount == 0).Select(j => new SideData()
                {
                    SideDescription = j.Side.SideDescription
                }).ToList();

            var deletes = _ctx.Sides
                .Where(e => !sides.Select(a => a.SideDescription).Contains(e.SideDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchSubtypes(IEnumerable<Subtype> subtypes)
        {
            var inserts = subtypes.GroupJoin(_ctx.Subtypes,
                    o => o.SubtypeDescription,
                    i => i.SubtypeDescription,
                    (o, i) => new { Subtype = o, SubtypeCount = i.Count() })
                .Where(j => j.SubtypeCount == 0).Select(j => new SubtypeData()
                {
                    SubtypeDescription = j.Subtype.SubtypeDescription
                }).ToList();

            var deletes = _ctx.Subtypes
                .Where(e => !subtypes.Select(a => a.SubtypeDescription).Contains(e.SubtypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchSupertypes(IEnumerable<Supertype> superTypes)
        {
            var inserts = superTypes.GroupJoin(_ctx.Supertypes,
                    o => o.SupertypeDescription,
                    i => i.SupertypeDescription,
                    (o, i) => new { Supertype = o, SupertypeCount = i.Count() })
                .Where(j => j.SupertypeCount == 0).Select(j => new SupertypeData()
                {
                    SupertypeDescription = j.Supertype.SupertypeDescription
                }).ToList();

            var deletes = _ctx.Supertypes
                .Where(e => !superTypes.Select(a => a.SupertypeDescription).Contains(e.SupertypeDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchTcgPlayerSkuConditions(IEnumerable<TcgPlayerSkuCondition> tcgPlayerSkuConditions)
        {
            var inserts = tcgPlayerSkuConditions.GroupJoin(_ctx.TcgPlayerSkuConditions,
                    o => o.ConditionDescription,
                    i => i.ConditionDescription,
                    (o, i) => new { TcgPlayerSkuCondition = o, TcgPlayerSkuConditionCount = i.Count() })
                .Where(j => j.TcgPlayerSkuConditionCount == 0).Select(j => new TcgPlayerSkuConditionData()
                {
                    ConditionDescription = j.TcgPlayerSkuCondition.ConditionDescription
                }).ToList();

            var deletes = _ctx.TcgPlayerSkuConditions
                .Where(e => !tcgPlayerSkuConditions.Select(a => a.ConditionDescription).Contains(e.ConditionDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchTcgPlayerSkuFinishes(IEnumerable<TcgPlayerSkuFinish> tcgPlayerSkuFinishes)
        {
            var inserts = tcgPlayerSkuFinishes.GroupJoin(_ctx.TcgPlayerSkuFinishes,
                    o => o.FinishDescription,
                    i => i.FinishDescription,
                    (o, i) => new { TcgPlayerSkuFinish = o, TcgPlayerSkuFinishCount = i.Count() })
                .Where(j => j.TcgPlayerSkuFinishCount == 0).Select(j => new TcgPlayerSkuFinishData()
                {
                    FinishDescription = j.TcgPlayerSkuFinish.FinishDescription
                }).ToList();

            var deletes = _ctx.TcgPlayerSkuFinishes
                .Where(e => !tcgPlayerSkuFinishes.Select(a => a.FinishDescription).Contains(e.FinishDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchTcgPlayerSkuLanguages(IEnumerable<TcgPlayerSkuLanguage> tcgPlayerSkuLanguages)
        {
            var inserts = tcgPlayerSkuLanguages.GroupJoin(_ctx.TcgPlayerSkuLanguages,
                    o => o.LanguageDescription,
                    i => i.LanguageDescription,
                    (o, i) => new { TcgPlayerSkuLanguage = o, TcgPlayerSkuLanguageCount = i.Count() })
                .Where(j => j.TcgPlayerSkuLanguageCount == 0).Select(j => new TcgPlayerSkuLanguageData()
                {
                    LanguageDescription = j.TcgPlayerSkuLanguage.LanguageDescription
                }).ToList();

            var deletes = _ctx.TcgPlayerSkuLanguages
                .Where(e => !tcgPlayerSkuLanguages.Select(a => a.LanguageDescription).Contains(e.LanguageDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchTcgPlayerSkuPrintings(IEnumerable<TcgPlayerSkuPrinting> tcgPlayerSkuPrintings)
        {
            var inserts = tcgPlayerSkuPrintings.GroupJoin(_ctx.TcgPlayerSkuPrintings,
                    o => o.PrintingDescription,
                    i => i.PrintingDescription,
                    (o, i) => new { TcgPlayerSkuPrinting = o, TcgPlayerSkuPrintingCount = i.Count() })
                .Where(j => j.TcgPlayerSkuPrintingCount == 0).Select(j => new TcgPlayerSkuPrintingData()
                {
                    PrintingDescription = j.TcgPlayerSkuPrinting.PrintingDescription
                }).ToList();

            var deletes = _ctx.TcgPlayerSkuPrintings
                .Where(e => !tcgPlayerSkuPrintings.Select(a => a.PrintingDescription).Contains(e.PrintingDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        private async Task PatchWaterMarks(IEnumerable<Watermark> waterMarks)
        {
            var inserts = waterMarks.GroupJoin(_ctx.Watermarks,
                    o => o.WatermarkDescription,
                    i => i.WatermarkDescription,
                    (o, i) => new { Watermark = o, WatermarkCount = i.Count() })
                .Where(j => j.WatermarkCount == 0).Select(j => new WatermarkData()
                {
                    WatermarkDescription = j.Watermark.WatermarkDescription
                }).ToList();

            var deletes = _ctx.Watermarks
                .Where(e => !waterMarks.Select(a => a.WatermarkDescription).Contains(e.WatermarkDescription)).ToList();

            _ctx.BulkInsert(inserts);
            _ctx.BulkDelete(deletes);
        }

        public Meta GetLatestMeta()
        {
            MetaData metaData = _ctx.Meta.OrderByDescending(m => m.DateApplied).FirstOrDefault();
            
            if(metaData == null)
            {
                return null;
            }

            Meta latestMeta = new Meta()
            {
                MetaID = metaData.pkMeta,
                MetaDate = metaData.MetaDate,
                Version = metaData.Version,
                DateApplied = metaData.DateApplied
            };

            return latestMeta;
        }

        public async Task AddMeta(Meta meta)
        {
            MetaData metaData = new MetaData()
            {
                MetaDate = meta.MetaDate,
                Version = meta.Version,
                DateApplied = meta.DateApplied
            };

            await _ctx.AddAsync(metaData);
            await _ctx.SaveChangesAsync();
        }

        public Task<PatchReferenceData> GetReferenceData()
        {
            throw new NotImplementedException();
        }

        public Task PatchSet(Set set)
        {
            throw new NotImplementedException();
        }
    }
}
