namespace MTGDeckBuilder.Core.Domain
{
    public record Keyword
    {
        public int? KeywordID { get; init; }
        public int? fkKeywordType { get; init; }
        public string KeywordDescription { get; init; }

        public virtual KeywordType KeywordType { get; init; }
    }
}
