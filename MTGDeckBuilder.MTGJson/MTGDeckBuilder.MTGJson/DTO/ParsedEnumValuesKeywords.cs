namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedEnumValuesKeywords
    {
        public string[]? AbilityWords { get; set; }
        public string[]? KeywordAbilities { get; set; }
        public string[]? KeywordActions { get; set; }
    }
}
