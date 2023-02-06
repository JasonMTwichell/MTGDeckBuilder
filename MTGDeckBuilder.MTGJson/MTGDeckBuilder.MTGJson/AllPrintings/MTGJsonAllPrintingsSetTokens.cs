using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public record MTGJsonAllPrintingsSetTokens
    {
        [JsonProperty("artist")]
        public string? Artist { get; set; }

        [JsonProperty("asciiName")]
        public string? AsciiName { get; set; }

        [JsonProperty("availability")]
        public string[]? Availability { get; set; }

        [JsonProperty("boosterTypes")]
        public string[]? BoosterTypes { get; set; }

        [JsonProperty("borderColor")]
        public string? BorderColor { get; set; }

        [JsonProperty("cardParts")]
        public string[]? CardParts { get; set; }

        [JsonProperty("colorIdentity")]
        public string[]? ColorIdentity { get; set; }

        [JsonProperty("colorIndicator")]
        public string[]? ColorIndicator { get; set; }

        [JsonProperty("colors")]
        public string[]? Colors { get; set; }

        [JsonProperty("faceName")]
        public string? FaceName { get; set; }

        [JsonProperty("faceFlavorName")]
        public string? FaceFlavorName { get; set; }

        [JsonProperty("finishes")]
        public string[]? Finishes { get; set; }

        [JsonProperty("flavorText")]
        public string? FlavorText { get; set; }
        
        [JsonProperty("frameEffects")]
        public string[]? FrameEffects { get; set; }

        [JsonProperty("frameVersion")]
        public string? FrameVersion { get; set; }

        [JsonProperty("hasFoil")]
        public bool? HasFoil { get; set; }

        [JsonProperty("hasNonFoil")]
        public bool? HasNonFoil { get; set; }

        [JsonProperty("identifiers")]
        public MTGJsonAllPrintingsSetCardIdentifiers? Identifiers { get; set; }

        [JsonProperty("isFullArt")]
        public bool? IsFullArt { get; set; }

        [JsonProperty("isFunny")]
        public bool? IsFunny { get; set; }

        [JsonProperty("isOnlineOnly")]
        public bool? IsOnlineOnly { get; set; }

        [JsonProperty("isPromo")]
        public bool? IsPromotionalPrinting { get; set; }

        [JsonProperty("isReprint")]
        public bool? IsReprint { get; set; }

        [JsonProperty("keywords")]
        public string[]? Keywords { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("layout")]
        public string? Layout { get; set; }

        [JsonProperty("loyalty")]
        public string? Loyalty { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("number")]
        public string? Number { get; set; }

        [JsonProperty("otherFaceIds")]
        public string[]? OtherFaceUUIDs { get; set; }

        [JsonProperty("power")]
        public string? Power { get; set; }

        [JsonProperty("promoTypes")]
        public string[]? PromoTypes { get; set; }

        [JsonProperty("reverseRelated")]
        public string[]? ReverseRelatedUUIDs { get; set; }

        [JsonProperty("securityStamp")]
        public string? SecurityStamp { get; set; }

        [JsonProperty("setCode")]
        public string? SetCode { get; set; }

        [JsonProperty("side")]
        public string? Side { get; set; }

        [JsonProperty("signature")]
        public string? Signature { get; set; }

        [JsonProperty("subtypes")]
        public string[]? Subtypes { get; set; }

        [JsonProperty("supertypes")]
        public string[]? Supertypes { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("toughness")]
        public string? Toughness { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("types")]
        public string[]? Types { get; set; }

        [JsonProperty("uuid")]
        public string? UUID { get; set; }

        [JsonProperty("watermark")]
        public string? Watermark { get; set; }
    }
}
