using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardPurchaseUrls
    {
        [JsonProperty("cardKingdom")]
        public string? CardKingdom { get; set; }

        [JsonProperty("cardKingdomEtched")]
        public string? CardKingdomEtched { get; set; }

        [JsonProperty("cardKingdomFoil")]
        public string? CardKingdomFoil { get; set; }

        [JsonProperty("cardMarket")]
        public string? CardMarket { get; set; }

        [JsonProperty("tcgplayer")]
        public string? Tcgplayer { get; set; }

        [JsonProperty("tcgplayerEtched")]
        public string? TcgplayerEtched { get; set; }
    }
}
