using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesCard
    {
        [JsonProperty("availability")]
        public string[]? Availabilities { get; set; }

        [JsonProperty("boosterTypes")]
        public string[]? BoosterTypes { get; set; }

        [JsonProperty("borderColor")]
        public string[]? BorderColors { get; set; }

        [JsonProperty("colorIdentity")]
        public string[]? ColorIdentities { get; set; }

        [JsonProperty("colorIndicator")]
        public string[]? ColorIndicators { get; set; }

        [JsonProperty("colors")]
        public string[]? Colors { get; set; }

        [JsonProperty("duelDeck")]
        public string[]? DuelDecks { get; set; }

        [JsonProperty("finishes")]
        public string[]? Finishes { get; set; }

        [JsonProperty("frameEffects")]
        public string[]? FrameEffects { get; set; }

        [JsonProperty("frameVersion")]
        public string[]? FrameVersions { get; set; }

        [JsonProperty("language")]
        public string[]? Languages { get; set; }

        [JsonProperty("layout")]
        public string[]? Layouts { get; set; }

        [JsonProperty("promoTypes")]
        public string[]? PromoTypes { get; set; }

        [JsonProperty("rarity")]
        public string[]? Rarities { get; set; }

        [JsonProperty("securityStamp")]
        public string[]? SecurityStamps { get; set; }

        [JsonProperty("side")]
        public string[]? Sides { get; set; }

        [JsonProperty("subtypes")]
        public string[]? Subtypes { get; set; }

        [JsonProperty("supertypes")]
        public string[]? Supertypes { get; set; }

        [JsonProperty("types")]
        public string[]? Types { get; set; }

        [JsonProperty("watermark")]
        public string[]? Watermarks { get; set; }
    }

}

