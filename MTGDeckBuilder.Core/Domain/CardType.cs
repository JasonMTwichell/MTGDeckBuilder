namespace MTGDeckBuilder.Core.Domain
{
    public record CardType
    {
        public int? CardTypeID { get; init; }
        public string CardTypeDescription { get; init; }
    }
}
