using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsRuling
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }


}
