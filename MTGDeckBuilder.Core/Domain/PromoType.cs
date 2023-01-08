namespace MTGDeckBuilder.Core.Domain
{
    public record PromoType
    {
        public int? PromoTypeID { get; init; }
        public string PromoTypeDescription { get; init; }
    }
}
