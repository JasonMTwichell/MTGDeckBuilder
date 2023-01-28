namespace MTGDeckBuilder.Core.Domain
{
    public record CardPrinting
    {
        public int? CardID { get; set; }
        public int? SetID { get; set; }
    }
}
