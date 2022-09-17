namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedPurchaseInformation
    {
        public int? PurchaseInformationID { get; set; }
        public string StoreFrontName { get; set; }
        public string CardURI { get; set; }
    }
}