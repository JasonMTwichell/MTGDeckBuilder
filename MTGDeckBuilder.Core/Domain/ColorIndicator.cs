namespace MTGDeckBuilder.Core.Domain
{
    public record ColorIndicator
    {
        public int? ColorIndicatorID { get; init; }
        public string ColorIndicatorDescription { get; init; }
    }
}
