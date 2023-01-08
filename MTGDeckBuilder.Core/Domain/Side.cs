namespace MTGDeckBuilder.Core.Domain
{
    public record Side
    {
        public int? SideID { get; init; }
        public string SideDescription { get; init; }
    }
}
