using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsLegalities
    {
        [JsonProperty("commander")]
        public string Commander { get; set; }

        [JsonProperty("duel")]
        public string Duel { get; set; }

        [JsonProperty("legacy")]
        public string Legacy { get; set; }

        [JsonProperty("oldschool")]
        public string Oldschool { get; set; }

        [JsonProperty("penny")]
        public string Penny { get; set; }

        [JsonProperty("premodern")]
        public string Premodern { get; set; }

        [JsonProperty("vintage")]
        public string Vintage { get; set; }
    }


}
