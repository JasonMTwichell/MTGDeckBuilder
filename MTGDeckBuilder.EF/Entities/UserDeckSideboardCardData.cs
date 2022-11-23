namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckSideboardCardData
    {
        public int fkUserDeckSideboard { get; set; }
        public string CardUUID { get; set; }
        public int NumCopies { get; set; }
        
        public virtual UserDeckSideboardData UserDeckSideboard { get; set; }
        public virtual CardData Card { get; set; }
    }
}
