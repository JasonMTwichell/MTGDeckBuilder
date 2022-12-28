namespace MTGDeckBuilder.Core.Domain
{
    public record struct UserDeckSideboardCardDelete
    {
        public int UserDeckID { get; set; }
        public string CardUUID { get; set; }
    }
}
