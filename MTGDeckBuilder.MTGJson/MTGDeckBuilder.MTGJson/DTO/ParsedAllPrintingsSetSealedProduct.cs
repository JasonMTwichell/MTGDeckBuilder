namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsSetSealedProduct
    {
        public string? UUID { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ParsedAllPrintingsIdentifiers? Identifiers { get; set; }
        public ParsedAllPrintingsPurchaseUrls? PurchaseUrls { get; set; }
    }
}
