namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedRuling
    {
        public int? RulingID { get; set; }
        public string RulingDate { get; set; }
        public string RulingText { get; set; }
    }
}