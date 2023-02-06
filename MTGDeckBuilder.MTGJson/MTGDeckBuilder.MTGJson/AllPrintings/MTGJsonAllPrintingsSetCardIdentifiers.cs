using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardIdentifiers
    {
        [JsonProperty("cardKingdomEtchedId")]
        public string? CardKingdomEtchedId { get; set; }

        [JsonProperty("cardKingdomFoilId")]
        public string? CardKingdomFoilId { get; set; }

        [JsonProperty("cardKingdomId")]
        public string? CardKingdomId { get; set; }

        [JsonProperty("cardsphereId")]
        public string? CardsphereId { get; set; }

        [JsonProperty("mcmId")]
        public string? McmId { get; set; }

        [JsonProperty("mcmMetaId")]
        public string? McmMetaId { get; set; }

        [JsonProperty("mtgArenaId")]
        public string? MtgArenaId { get; set; }

        [JsonProperty("mtgoFoilId")]
        public string? MtgoFoilId { get; set; }

        [JsonProperty("mtgoId")]
        public string? MtgoId { get; set; }

        [JsonProperty("mtgjsonV4Id")]
        public string? MtgjsonV4Id { get; set; }

        [JsonProperty("multiverseId")]
        public string? MultiverseId { get; set; }

        [JsonProperty("scryfallId")]
        public string? ScryfallId { get; set; }

        [JsonProperty("scryfallOracleId")]
        public string? ScryfallOracleId { get; set; }

        [JsonProperty("scryfallIllustrationId")]
        public string? ScryfallIllustrationId { get; set; }

        [JsonProperty("tcgplayerProductId")]
        public string? TcgplayerProductId { get; set; }

        [JsonProperty("tcgplayerEtchedProductId")]
        public string? TcgplayerEtchedProductId { get; set; }
    }
}
