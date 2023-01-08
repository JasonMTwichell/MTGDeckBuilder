namespace MTGDeckBuilder.Core.Domain
{
    public record Rarity
    {
        public int? RarityID { get; init; }
        public string RarityDescription { get; init; }
    }
}
