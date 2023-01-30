namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardPrintingData
    {
        public int? pkSetCardPrinting { get; set; }
        public int? fkSetCard { get; set; }
        public string PrintingSetCode { get; set; }
    }
}
