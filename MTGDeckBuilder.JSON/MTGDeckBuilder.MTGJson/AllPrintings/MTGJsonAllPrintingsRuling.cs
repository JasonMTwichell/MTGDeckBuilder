using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.Parse
{
    public class MTGJsonAllPrintingsRuling
    {
        [JsonProperty("date")]
        public string RulingDate { get; set; }

        [JsonProperty("text")]
        public string RulingText { get; set; }
    }
}
