using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardRuling
    {
        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }
    }
}
