namespace MTGDeckBuilder.Core.Domain
{
    public record FrameEffect
    {
        public int? FrameEffectID { get; init; }
        public string FrameEffectDescription { get; init; }
    }
}
