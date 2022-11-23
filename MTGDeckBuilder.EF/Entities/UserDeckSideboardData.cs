namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckSideboardData
    {
        public int pkUserDeckSideBoard { get; set; }
        public int fkUserDeck { get; set; }

        public virtual UserDeckData UserDeck { get; set; }
        public virtual ICollection<UserDeckSideboardCardData> Cards { get; set; }
    }
}
