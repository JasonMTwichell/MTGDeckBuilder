using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsForeignData
    {
        [JsonProperty("faceName")]
        public string FaceName { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("flavorText")]
        public string FlavorText { get; set; }

        [JsonProperty("multiverseId")]
        public string MultiverseID { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
