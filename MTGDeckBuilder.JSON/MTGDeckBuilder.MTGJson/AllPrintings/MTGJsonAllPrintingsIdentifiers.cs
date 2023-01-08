using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsIdentifiers
    {
        [JsonProperty("cardKingdomId")]
        public string CardKingdomId { get; set; }

        [JsonProperty("cardsphereId")]
        public string CardsphereId { get; set; }

        [JsonProperty("mcmId")]
        public string McmId { get; set; }

        [JsonProperty("mtgjsonV4Id")]
        public string MtgjsonV4Id { get; set; }

        [JsonProperty("multiverseId")]
        public string MultiverseId { get; set; }

        [JsonProperty("scryfallId")]
        public string ScryfallId { get; set; }

        [JsonProperty("scryfallIllustrationId")]
        public string ScryfallIllustrationId { get; set; }

        [JsonProperty("scryfallOracleId")]
        public string ScryfallOracleId { get; set; }

        [JsonProperty("tcgplayerProductId")]
        public string TcgplayerProductId { get; set; }
    }


}
