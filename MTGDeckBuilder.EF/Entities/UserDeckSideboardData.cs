namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckSideboardData
    {
        public int fkUserDeck { get; set; }

        public UserDeckData UserDeck { get; set; }
        public virtual ICollection<CardData> Cards { get; set; }
    }
}
