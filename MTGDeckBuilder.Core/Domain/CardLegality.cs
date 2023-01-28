namespace MTGDeckBuilder.Core.Domain
{
    public record CardLegality
    {
        public int CardID { get; set; }
        public int FormatID { get; set; }
        public bool IsLegal { get; set; }
    }
}
