using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetSealedProduct
    {
        [JsonProperty("identifiers")]
        public MTGJsonAllPrintingsSetCardIdentifiers Identifiers { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("purchaseUrls")]
        public MTGJsonAllPrintingsSetCardPurchaseUrls PurchaseUrls { get; set; }

        [JsonProperty("releaseDate")]
        public object ReleaseDate { get; set; }

        [JsonProperty("uuid")]
        public string? Uuid { get; set; }
    }
}
