namespace MTGDeckBuilder.Core.Domain
{
    public record Watermark
    {
        public int? WatermarkID { get; init; }
        public string WatermarkDescription { get; init; }
    }
}
