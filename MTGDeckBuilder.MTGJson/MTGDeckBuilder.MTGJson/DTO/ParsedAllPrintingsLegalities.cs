namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsLegalities
    {
        public string? Commander { get; set; }
        public string? Duel { get; set; }
        public string? Legacy { get; set; }
        public string? Oldschool { get; set; }
        public string? Penny { get; set; }
        public string? Premodern { get; set; }
        public string? Vintage { get; set; }
    }
}
