namespace MTGDeckBuilder.Core.Domain
{
    public record struct UserDeckSideboardCardsUpdate
    {
        public int UserDeckID { get; set; }
        public string CardUUID { get; set; }
        public int NumCopies { get; set; }
    }
}
