using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetMeta
    {
        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }
    }
}
