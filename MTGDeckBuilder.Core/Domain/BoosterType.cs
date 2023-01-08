namespace MTGDeckBuilder.Core.Domain
{
    public record BoosterType
    {
        public int? BoosterTypeID { get; init; }
        public string BoosterTypeDescription { get; init; }
    }
}
