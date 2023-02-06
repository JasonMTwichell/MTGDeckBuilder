using MTGDeckBuilder.MTGJson.AllPrintings;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsSetToken
    {
        public string? Artist { get; set; }
        public string? AsciiName { get; set; }
        public string[]? Availability { get; set; }
        public string[]? BoosterTypes { get; set; }
        public string? BorderColor { get; set; }
        public string[]? CardParts { get; set; }
        public string[]? ColorIdentity { get; set; }
        public string[]? ColorIndicator { get; set; }
        public string[]? Colors { get; set; }
        public string? FaceName { get; set; }
        public string? FaceFlavorName { get; set; }
        public string[]? Finishes { get; set; }
        public string? FlavorText { get; set; }
        public string[]? FrameEffects { get; set; }
        public string? FrameVersion { get; set; }
        public bool? HasFoil { get; set; }
        public bool? HasNonFoil { get; set; }
        public MTGJsonAllPrintingsSetCardIdentifiers? Identifiers { get; set; }
        public bool? IsFullArt { get; set; }
        public bool? IsFunny { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public bool? IsPromotionalPrinting { get; set; }
        public bool? IsReprint { get; set; }
        public string[]? Keywords { get; set; }
        public string? Language { get; set; }
        public string? Layout { get; set; }
        public string? Loyalty { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string[]? OtherFaceUUIDs { get; set; }
        public string? Power { get; set; }
        public string[]? PromoTypes { get; set; }
        public string[]? ReverseRelatedUUIDs { get; set; }
        public string? SecurityStamp { get; set; }
        public string? SetCode { get; set; }
        public string? Side { get; set; }
        public string? Signature { get; set; }
        public string[]? Subtypes { get; set; }
        public string[]? Supertypes { get; set; }
        public string? Text { get; set; }
        public string? Toughness { get; set; }
        public string? Type { get; set; }
        public string[]? Types { get; set; }
        public string? UUID { get; set; }
        public string? Watermark { get; set; }
    }
}
