namespace MTGDeckBuilder.Core.Domain
{
    public record SetType
    {
        public int? SetTypeID { get; init; }
        public string SetTypeDescription { get; init; }
    }
}
