namespace MTGDeckBuilder.Core.Domain
{
    public record Subtype
    {
        public int? SubtypeID { get; init; }
        public string SubtypeDescription { get; init; }
    }
}
