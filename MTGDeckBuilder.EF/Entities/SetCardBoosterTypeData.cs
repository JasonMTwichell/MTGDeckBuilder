namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardBoosterTypeData
    {
        public int fkSetCard { get; set; }
        public int fkBoosterType { get; set; }
        public SetCardData SetCard { get; set; }
        public BoosterTypeData BoosterType { get; set; }
    }
}
