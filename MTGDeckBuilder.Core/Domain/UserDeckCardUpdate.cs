namespace MTGDeckBuilder.Core.Domain
{
    public record struct UserDeckCardUpdate
    {
        public int UserDeckID { get; set; }
        public string CardUUID { get; set; }
        public int NumCopies { get; set; }
    }
}
