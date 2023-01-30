namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardPurchaseUrlData
    {
        public int? pkSetCardPurchaseUrl { get; set; }
        public int? fkSetCard { get; set; }
        public string PurchaseUrlDescription { get; set; }
        public string PurchaseUrl { get; set; }
    }
}
