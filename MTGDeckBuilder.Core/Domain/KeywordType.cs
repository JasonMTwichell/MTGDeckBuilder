namespace MTGDeckBuilder.Core.Domain
{
    public record KeywordType
    {
        public int? KeywordTypeID { get; init; }
        public string KeywordTypeDescription { get; init; }
    }
}
