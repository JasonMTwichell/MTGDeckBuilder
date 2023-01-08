namespace MTGDeckBuilder.Core.Domain
{
    public record Layout
    {
        public int? LayoutID { get; init; }
        public string LayoutDescription { get; init; }
    }
}
