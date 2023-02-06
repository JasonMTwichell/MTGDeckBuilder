using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCard
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

        [JsonProperty("colors")]
        public string[]? Colors { get; set; }

        [JsonProperty("convertedManaCost")]
        public double? ConvertedManaCost { get; set; }

        [JsonProperty("edhrecRank")]
        public int? EdhrecRank { get; set; }

        [JsonProperty("finishes")]
        public string[]? Finishes { get; set; }

        [JsonProperty("foreignData")]
        public MTGJsonAllPrintingsSetCardForeignData[]? ForeignData { get; set; }

        [JsonProperty("frameVersion")]
        public string? FrameVersion { get; set; }

        [JsonProperty("hasFoil")]
        public bool? HasFoil { get; set; }

        [JsonProperty("hasNonFoil")]
        public bool? HasNonFoil { get; set; }

        [JsonProperty("identifiers")]
        public MTGJsonAllPrintingsSetCardIdentifiers? Identifiers { get; set; }

        [JsonProperty("isReprint")]
        public bool? IsReprint { get; set; }

        [JsonProperty("keywords")]
        public string[]? Keywords { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("layout")]
        public string? Layout { get; set; }

        [JsonProperty("legalities")]
        public MTGJsonAllPrintingsSetCardLegalities? Legalities { get; set; }

        [JsonProperty("manaCost")]
        public string? ManaCost { get; set; }

        [JsonProperty("manaValue")]
        public double? ManaValue { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("number")]
        public string? Number { get; set; }

        [JsonProperty("originalText")]
        public string? OriginalText { get; set; }

        [JsonProperty("originalType")]
        public string? OriginalType { get; set; }

        [JsonProperty("printings")]
        public string[]? Printings { get; set; }

        [JsonProperty("purchaseUrls")]
        public MTGJsonAllPrintingsSetCardPurchaseUrls? PurchaseUrls { get; set; }

        [JsonProperty("rarity")]
        public string? Rarity { get; set; }

        [JsonProperty("rulings")]
        public MTGJsonAllPrintingsSetCardRuling[]? Rulings { get; set; }

        [JsonProperty("setCode")]
        public string? SetCode { get; set; }

        [JsonProperty("subtypes")]
        public string[]? Subtypes { get; set; }

        [JsonProperty("supertypes")]
        public string[]? Supertypes { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("types")]
        public string[]? Types { get; set; }

        [JsonProperty("uuid")]
        public string? UUID { get; set; }


        [JsonProperty("flavorText")]
        public string? FlavorText { get; set; }

        [JsonProperty("power")]
        public string? Power { get; set; }

        [JsonProperty("toughness")]
        public string? Toughness { get; set; }

        [JsonProperty("isReserved")]
        public bool? IsReserved { get; set; }

        [JsonProperty("hasContentWarning")]
        public bool? HasContentWarning { get; set; }

        [JsonProperty("colorIndicator")]
        public string[]? ColorIndicator { get; set; }

        [JsonProperty("faceConvertedManaCost")]
        public double? FaceConvertedManaCost { get; set; }

        [JsonProperty("faceFlavorName")]
        public string? FaceFlavorName { get; set; }

        [JsonProperty("faceManaValue")]
        public double? FaceManaValue { get; set; }

        [JsonProperty("faceName")]
        public string? FaceName { get; set; }

        [JsonProperty("flavorName")]
        public string? FlavorName { get; set; }

        [JsonProperty("frameEffects")]
        public string[]? FrameEffects { get; set; }

        [JsonProperty("hand")]
        public string? HandSizeModifier { get; set; }

        [JsonProperty("hasAlternativeDeckLimit")]
        public bool? HasAlternativeDeckLimit { get; set; }

        [JsonProperty("isAlternative")]
        public bool? IsAlternativePrinting { get; set; }

        [JsonProperty("isFullArt")]
        public bool? IsFullArt { get; set; }

        [JsonProperty("isFunny")]
        public bool? IsFunny { get; set; }

        [JsonProperty("isOnlineOnly")]
        public bool? IsOnlineOnly { get; set; }

        [JsonProperty("isOversized")]
        public bool? IsOversized { get; set; }

        [JsonProperty("isPromo")]
        public bool? IsPromotionalPrinting { get; set; }

        [JsonProperty("isRebalanced")]
        public bool? IsRebalancedForAlchemy { get; set; }

        [JsonProperty("isStarter")]
        public bool? IsInStarterDeck { get; set; }

        [JsonProperty("isStorySpotlight")]
        public bool? IsStorySpotlight { get; set; }

        [JsonProperty("isTextless")]
        public bool? IsTextless { get; set; }

        [JsonProperty("isTimeshifted")]
        public bool? IsTimeshifted { get; set; }

        [JsonProperty("leadershipSkills")]
        public MTGJsonAllPrintingsSetCardLeadershipSkills? LeadershipSkills { get; set; }

        [JsonProperty("life")]
        public string? LifeTotalModifier { get; set; }

        [JsonProperty("loyalty")]
        public string? Loyalty { get; set; }

        [JsonProperty("originalPrintings")]
        public string[]? OriginalPrintingUUIDs { get; set; }

        [JsonProperty("originalReleaseDate")]
        public DateTime? OriginalReleaseDate { get; set; }

        [JsonProperty("otherFaceIds")]
        public string[]? OtherFaceUUIDs { get; set; }

        [JsonProperty("promoTypes")]
        public string[]? PromoTypes { get; set; }

        [JsonProperty("rebalancedPrintings")]
        public string[]? RebalancedPrintingUUIDs { get; set; }

        [JsonProperty("securityStamp")]
        public string? SecurityStamp { get; set; }

        [JsonProperty("side")]
        public string? Side { get; set; }

        [JsonProperty("signature")]
        public string? Signature { get; set; }

        [JsonProperty("variations")]
        public string[]? Variations { get; set; }

        [JsonProperty("watermark")]
        public string? Watermark { get; set; }
    }
}
