namespace MTGDeckBuilder.Core.Domain
{
    public record ColorIdentity
    {
        public int? ColorIdentityID { get; init; }
        public string ColorIdentityDescription { get; init; }
    }
}
