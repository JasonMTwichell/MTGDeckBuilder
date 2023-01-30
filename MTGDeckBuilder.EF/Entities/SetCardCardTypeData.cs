namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardCardTypeData
    {
        public int fkSetCard { get; set; }
        public int fkCardType { get; set; }
        public SetCardData SetCard { get; set; }
        public CardTypeData CardType { get; set; }
    }
}
