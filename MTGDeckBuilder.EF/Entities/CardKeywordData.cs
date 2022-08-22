namespace MTGDeckBuilder.EF.Entities
{
    public class CardKeywordData
    {
        public string fkCard { get; set; }
        public string fkKeyword { get; set; }

        public virtual CardData Card { get; set; }
        public virtual KeywordData Keyword { get; set; }
    }
}
