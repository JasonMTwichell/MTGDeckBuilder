namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckSideboardCardData
    {
        public string fkCard { get; set; }
        public int fkUserDeckSideboard { get; set; }

        public virtual CardData Card { get; set; }
        public virtual UserDeckSideboardData UserDeckSideboard { get; set; }
    }
}
