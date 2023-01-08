namespace MTGDeckBuilder.Core.Domain
{
    public record BorderColor
    {
        public int? BorderColorID { get; init; }
        public string BorderColorDescription { get; init; }
    }
}
