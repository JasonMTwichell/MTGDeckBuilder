using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardPurchaseUrls
    {
        [JsonProperty("cardKingdom")]
        public string? CardKingdom { get; set; }

        [JsonProperty("tcgplayer")]
        public string? Tcgplayer { get; set; }
    }
}
