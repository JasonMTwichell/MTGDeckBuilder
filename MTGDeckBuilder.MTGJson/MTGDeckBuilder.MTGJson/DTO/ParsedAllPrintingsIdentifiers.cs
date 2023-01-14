namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsIdentifiers
    {
        public string? CardKingdomId { get; set; }
        public string? CardsphereId { get; set; }
        public string? McmId { get; set; }
        public string? MtgjsonV4Id { get; set; }
        public string? MultiverseId { get; set; }
        public string? ScryfallId { get; set; }
        public string? ScryfallIllustrationId { get; set; }
        public string? ScryfallOracleId { get; set; }
        public string? TcgplayerProductId { get; set; }
    }
}
