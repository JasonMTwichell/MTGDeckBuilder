using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCard
    {
        [JsonProperty("artist")]
        public string? Artist { get; set; }

        [JsonProperty("availability")]
        public string[]? Availability { get; set; }

        [JsonProperty("boosterTypes")]
        public string[]? BoosterTypes { get; set; }

        [JsonProperty("borderColor")]
        public string? BorderColor { get; set; }

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
    }
}
