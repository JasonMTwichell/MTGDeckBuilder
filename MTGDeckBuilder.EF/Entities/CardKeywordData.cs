namespace MTGDeckBuilder.EF.Entities
{
    public class CardKeywordData
    {
        public int fkCard { get; set; }
        public int fkKeyword { get; set; }

        public virtual CardData Card { get; set; }
        public virtual KeywordData Keyword { get; set; }
    }
}
