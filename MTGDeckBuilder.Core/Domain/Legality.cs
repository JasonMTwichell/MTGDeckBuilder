namespace MTGDeckBuilder.Core.Domain
{
    public record Legality
    {
        public int? FormatID { get; set; }
        public string FormatName { get; set; }
    }
}
