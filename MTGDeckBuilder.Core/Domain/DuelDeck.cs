namespace MTGDeckBuilder.Core.Domain
{
    public record DuelDeck
    {
        public int? DuelDeckID { get; init; }
        public string DuelDeckDescription { get; init; }
    }
}
