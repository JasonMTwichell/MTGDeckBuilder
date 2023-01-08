namespace MTGDeckBuilder.Core.Domain
{
    public record SecurityStamp
    {
        public int? SecurityStampID { get; init; }
        public string SecurityStampDescription { get; init; }
    }
}
