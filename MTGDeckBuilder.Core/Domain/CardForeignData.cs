namespace MTGDeckBuilder.Core.Domain
{
    public record CardForeignData
    {
        public int? CardForeignDataID { get; set; }
        public int CardID { get; set; }
        public string? FaceName { get; set; }
        public string? Language { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? FlavorText { get; set; }
        public string? MultiverseID { get; set; }
        public string? Text { get; set; }
    }
}
