using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.Meta
{
    internal class MTGJsonMetaData
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
