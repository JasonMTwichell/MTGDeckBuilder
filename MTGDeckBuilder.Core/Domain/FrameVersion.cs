namespace MTGDeckBuilder.Core.Domain
{
    public record FrameVersion
    {
        public int? FrameVersionID { get; init; }
        public string FrameVersionDescription { get; init; }
    }
}
