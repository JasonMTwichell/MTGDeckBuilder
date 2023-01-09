using MTGDeckBuilder.Core.Domain;
using System.Collections.Generic;

namespace MTGDeckBuilder.Patcher
{
    public record PatchDataCommand
    {
        public Meta MetaData { get; init; }
        public IEnumerable<Availability> Availabilities { get; init; }
        public IEnumerable<BoosterType> BoosterTypes { get; init; }
        public IEnumerable<BorderColor> BorderColors { get; init; }
        public IEnumerable<CardType> CardTypes { get; init; }
        public IEnumerable<Color> Colors { get; init; }
        public IEnumerable<ColorIdentity> ColorIdentities { get; init; }
        public IEnumerable<ColorIndicator> ColorIndicators { get; init; }
        public IEnumerable<DeckType> DeckTypes { get; init; }
        public IEnumerable<DuelDeck> DuelDecks { get; init; }
        public IEnumerable<Finish> Finishes { get; init; }
        public IEnumerable<ForeignDataLanguage> ForeignDataLanguages { get; init; }
        public IEnumerable<FrameEffect> FrameEffects { get; init; }
        public IEnumerable<FrameVersion> FrameVersions { get; init; }
        public IEnumerable<Keyword> Keywords { get; init; }        
        public IEnumerable<Language> Languages { get; init; }
        public IEnumerable<Layout> Layouts { get; init; }
        public IEnumerable<PromoType> PromoTypes { get; init; }
        public IEnumerable<Rarity> Rarities { get; init; }
        public IEnumerable<SecurityStamp> SecurityStamps { get; init; }
        public IEnumerable<SetType> SetTypes { get; init; }
        public IEnumerable<Side> Sides { get; init; }
        public IEnumerable<Subtype> Subtypes { get; init; }
        public IEnumerable<Supertype> Supertypes { get; init; }
        public IEnumerable<TcgPlayerSkuCondition> TcgPlayerSkuConditions { get; init; }
        public IEnumerable<TcgPlayerSkuFinish> TcgPlayerSkuFinishes { get; init; }
        public IEnumerable<TcgPlayerSkuLanguage> TcgPlayerSkuLanguages { get; init; }
        public IEnumerable<TcgPlayerSkuPrinting> TcgPlayerSkuPrintings { get; init; }
        public IEnumerable<Watermark> Watermarks { get; init; }
    }
}
