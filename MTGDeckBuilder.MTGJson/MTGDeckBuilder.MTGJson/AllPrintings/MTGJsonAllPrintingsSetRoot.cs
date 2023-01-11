using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetRoot
    {
        [JsonProperty("meta")]
        public MTGJsonAllPrintingsSetMeta Meta { get; set; }

        [JsonProperty("data")]
        public MTGJsonAllPrintingsSet Data { get; set; }
    }
}
