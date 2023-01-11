using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetTranslations
    {
        [JsonProperty("Chinese Simplified")]
        public string? ChineseSimplified { get; set; }

        [JsonProperty("Chinese Traditional")]
        public string? ChineseTraditional { get; set; }

        [JsonProperty("French")]
        public string? French { get; set; }

        [JsonProperty("German")]
        public string? German { get; set; }

        [JsonProperty("Italian")]
        public string? Italian { get; set; }

        [JsonProperty("Japanese")]
        public string? Japanese { get; set; }

        [JsonProperty("Korean")]
        public string? Korean { get; set; }

        [JsonProperty("Portuguese (Brazil)")]
        public string? PortugueseBrazil { get; set; }

        [JsonProperty("Russian")]
        public string? Russian { get; set; }

        [JsonProperty("Spanish")]
        public string? Spanish { get; set; }
    }
}
