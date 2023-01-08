namespace MTGDeckBuilder.Core.Domain
{
    public record Color
    {
        public int? ColorID { get; init; }
        public string ColorDescription { get; init; }
    }
}
