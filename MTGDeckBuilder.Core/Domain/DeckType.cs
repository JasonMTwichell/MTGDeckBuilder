namespace MTGDeckBuilder.Core.Domain
{
    public record DeckType
    {
        public int? DeckTypeID { get; init; }
        public string DeckTypeDescription { get; init; }
    }
}
