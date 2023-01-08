namespace MTGDeckBuilder.Core.Domain
{
    public record TcgPlayerSkuPrinting
    {
        public int? TcgPlayerSkuPrintingID { get; init; }
        public string PrintingDescription { get; init; }
    }
}
