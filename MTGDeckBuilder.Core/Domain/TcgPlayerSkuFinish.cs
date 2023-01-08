namespace MTGDeckBuilder.Core.Domain
{
    public record TcgPlayerSkuFinish
    {
        public int? TcgPlayerSkuFinishID { get; init; }
        public string FinishDescription { get; init; }
    }
}
