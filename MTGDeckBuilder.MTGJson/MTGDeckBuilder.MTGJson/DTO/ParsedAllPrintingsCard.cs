namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsCard
    {
        public string? Artist { get; set; }
        public string[]? Availability { get; set; }
        public string[]? BoosterTypes { get; set; }
        public string? BorderColor { get; set; }
        public string[]? ColorIdentity { get; set; }
        public string[]? Colors { get; set; }
        public double? ConvertedManaCost { get; set; }
        public int? EdhrecRank { get; set; }
        public string[]? Finishes { get; set; }
        public ParsedAllPrintingsForeignData[]? ForeignData { get; set; }
        public string? FrameVersion { get; set; }
        public bool? HasFoil { get; set; }
        public bool? HasNonFoil { get; set; }
        public ParsedAllPrintingsIdentifiers? Identifiers { get; set; }
        public bool? IsReprint { get; set; }
        public string[]? Keywords { get; set; }
        public string? Language { get; set; }
        public string? Layout { get; set; }
        public ParsedAllPrintingsLegalities? Legalities { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? OriginalText { get; set; }
        public string? OriginalType { get; set; }
        public string[]? Printings { get; set; }
        public ParsedAllPrintingsPurchaseUrls? PurchaseUrls { get; set; }
        public string? Rarity { get; set; }
        public ParsedAllPrintingsRuling? Rulings { get; set; }
        public string? SetCode { get; set; }
        public string[]? Subtypes { get; set; }
        public string[]? Supertypes { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string[]? Types { get; set; }
        public string? UUID { get; set; }
    }
}
