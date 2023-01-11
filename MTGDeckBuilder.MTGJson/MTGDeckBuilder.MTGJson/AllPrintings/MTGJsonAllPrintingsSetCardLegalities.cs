using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardLegalities
    {
        [JsonProperty("commander")]
        public string? Commander { get; set; }

        [JsonProperty("duel")]
        public string? Duel { get; set; }

        [JsonProperty("legacy")]
        public string? Legacy { get; set; }

        [JsonProperty("oldschool")]
        public string? Oldschool { get; set; }

        [JsonProperty("penny")]
        public string? Penny { get; set; }

        [JsonProperty("premodern")]
        public string? Premodern { get; set; }

        [JsonProperty("vintage")]
        public string? Vintage { get; set; }

        [JsonProperty("pauper")]
        public string? Pauper { get; set; }

        [JsonProperty("paupercommander")]
        public string? Paupercommander { get; set; }

        [JsonProperty("modern")]
        public string? Modern { get; set; }

        [JsonProperty("pioneer")]
        public string? Pioneer { get; set; }

        [JsonProperty("alchemy")]
        public string? Alchemy { get; set; }

        [JsonProperty("brawl")]
        public string? Brawl { get; set; }

        [JsonProperty("explorer")]
        public string? Explorer { get; set; }

        [JsonProperty("future")]
        public string? Future { get; set; }

        [JsonProperty("gladiator")]
        public string? Gladiator { get; set; }

        [JsonProperty("historic")]
        public string? Historic { get; set; }

        [JsonProperty("historicbrawl")]
        public string? Historicbrawl { get; set; }

        [JsonProperty("standard")]
        public string? Standard { get; set; }
    }
}
