namespace MTGDeckBuilder.Core.Domain
{
    public record Finish
    {
        public int? FinishID { get; init; }
        public string FinishDescription { get; init; }
    }
}
