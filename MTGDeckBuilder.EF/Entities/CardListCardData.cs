namespace MTGDeckBuilder.EF.Entities
{
    public class CardListCardData
    {
        public int fkCardList { get; set; }
        public string CardUUID { get; set; }

        public virtual CardListData List { get; set; }
        public virtual CardData CardData { get; set; }
    }
}
