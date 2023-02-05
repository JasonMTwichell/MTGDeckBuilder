namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardKeywordData
    {
        public int fkSetCard { get; set; }
        public int fkKeyword { get; set; }
        public SetCardData SetCard { get; set; }
        public KeywordData Keyword { get; set; }
    }
}
