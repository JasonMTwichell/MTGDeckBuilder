namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckSideboardData
    {
        public int pkSideBoardData { get; set; }
        public int fkUserDeck { get; set; }

        public UserDeckData UserDeck { get; set; }
        public virtual ICollection<UserDeckSideboardCardData> Cards { get; set; }
    }
}
