namespace MTGDeckBuilder.Core.Domain
{
    public record Type
    {
        public int? TypeID { get; init; }
        public string TypeDescription { get; init; }
    }
}
