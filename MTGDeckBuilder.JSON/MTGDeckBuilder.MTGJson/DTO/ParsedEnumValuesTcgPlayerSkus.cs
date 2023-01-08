namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedEnumValuesTcgPlayerSkus
    {
        public string[]? Conditions { get; set; }
        public string[]? Finishes { get; set; }
        public string[]? Languages { get; set; }
        public string[]? Printings { get; set; }
    }
}
