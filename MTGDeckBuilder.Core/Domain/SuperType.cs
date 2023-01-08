namespace MTGDeckBuilder.Core.Domain
{
    public record Supertype
    {
        public int? SupertypeID { get; init; }
        public string SupertypeDescription { get; init; }
    }
}
