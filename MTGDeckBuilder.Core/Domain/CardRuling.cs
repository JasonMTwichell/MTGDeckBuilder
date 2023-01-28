namespace MTGDeckBuilder.Core.Domain
{
    public record CardRuling
    {
        public int? CardRulingID { get; set; }
        public int? CardID { get; set; } 
        public string? Date { get; set; }
        public string? Text { get; set; }
    }
}
