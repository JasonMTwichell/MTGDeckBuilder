namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsPurchaseUrls
    {
        public string? CardKingdom { get; set; }
        public string? CardKingdomEtched { get; set; }
        public string? CardKingdomFoil { get; set; }
        public string? CardMarket { get; set; }
        public string? Tcgplayer { get; set; }
        public string? TcgplayerEtched { get; set; }
    }
}
