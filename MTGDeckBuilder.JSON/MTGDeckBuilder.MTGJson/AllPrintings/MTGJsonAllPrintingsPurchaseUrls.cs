using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsPurchaseUrls
    {
        [JsonProperty("cardKingdom")]
        public string CardKingdom { get; set; }

        [JsonProperty("tcgplayer")]
        public string Tcgplayer { get; set; }
    }


}
