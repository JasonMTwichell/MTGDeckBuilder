namespace MTGDeckBuilder.EF.Entities
{
    public class PurchaseInformationData
    {
        public int pkPurchaseInformation { get; set; }
        public int fkCard { get; set; }
        public string StorefrontName { get; set; }
        public string CardURI { get; set; }

        public virtual CardData Card { get; set; }
    }
}