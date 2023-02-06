using MTGDeckBuilder.MTGJson.AllPrintings;
using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsSetCard
    {
        public string? Artist { get; set; }
        public string? AsciiName { get; set; }
        public string[]? Availability { get; set; }
        public string[]? BoosterTypes { get; set; }
        public string? BorderColor { get; set; }
        public string[]? CardParts { get; set; }
        public string[]? ColorIdentity { get; set; }
        public string[]? Colors { get; set; }
        public double? ConvertedManaCost { get; set; }
        public int? EdhrecRank { get; set; }
        public string[]? Finishes { get; set; }
        public ParsedAllPrintingsForeignData[]? ForeignData { get; set; }
        public string? FrameVersion { get; set; }
        public bool? HasFoil { get; set; }
        public bool? HasNonFoil { get; set; }
        public ParsedAllPrintingsIdentifiers? Identifiers { get; set; }
        public bool? IsReprint { get; set; }
        public string[]? Keywords { get; set; }
        public string? Language { get; set; }
        public string? Layout { get; set; }
        public ParsedAllPrintingsLegalities? Legalities { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? OriginalText { get; set; }
        public string? OriginalType { get; set; }
        public string[]? Printings { get; set; }
        public ParsedAllPrintingsPurchaseUrls? PurchaseUrls { get; set; }
        public string? Rarity { get; set; }
        public ParsedAllPrintingsRuling[]? Rulings { get; set; }
        public string? SetCode { get; set; }
        public string[]? Subtypes { get; set; }
        public string[]? Supertypes { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string[]? Types { get; set; }
        public string? UUID { get; set; }

        public string? FlavorText { get; set; }
        public string? Power { get; set; }
        public string? Toughness { get; set; }
        public bool? IsReserved { get; set; }
        public bool? HasContentWarning { get; set; }
        public string[]? ColorIndicator { get; set; }
        public double? FaceConvertedManaCost { get; set; }
        public string? FaceFlavorName { get; set; }
        public double? FaceManaValue { get; set; }
        public string? FaceName { get; set; }
        public string? FlavorName { get; set; }
        public string[]? FrameEffects { get; set; }
        public string? HandSizeModifier { get; set; }
        public bool? HasAlternativeDeckLimit { get; set; }
        public bool? IsAlternativePrinting { get; set; }
        public bool? IsFullArt { get; set; }
        public bool? IsFunny { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public bool? IsOversized { get; set; }
        public bool? IsPromotionalPrinting { get; set; }
        public bool? IsRebalancedForAlchemy { get; set; }
        public bool? IsInStarterDeck { get; set; }
        public bool? IsStorySpotlight { get; set; }
        public bool? IsTextless { get; set; }
        public bool? IsTimeshifted { get; set; }
        public ParsedAllPrintingsSetCardLeadershipSkills? LeadershipSkills { get; set; }
        public string? LifeTotalModifier { get; set; }
        public string? Loyalty { get; set; }
        public string[]? OriginalPrintingUUIDs { get; set; }
        public DateTime? OriginalReleaseDate { get; set; }
        public string[]? OtherFaceUUIDs { get; set; }
        public string[]? PromoTypes { get; set; }
        public string[]? RebalancedPrintingUUIDs { get; set; }
        public string? SecurityStamp { get; set; }
        public string? Side { get; set; }
        public string? Signature { get; set; }
        public string[]? Variations { get; set; }
        public string? Watermark { get; set; }
    }
}
