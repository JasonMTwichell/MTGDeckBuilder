namespace MTGDeckBuilder.Core.Domain
{
    public record TcgPlayerSkuCondition
    {
        public int? TcgPlayerSkuConditionID { get; init; }
        public string ConditionDescription { get; init; }
    }
}
