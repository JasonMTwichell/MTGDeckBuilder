namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardFinishData
    {
        public int fkSetCard { get; set; }
        public int fkFinish { get; set; }
        public SetCardData SetCard { get; set; }
        public FinishData Finish { get; set; }
    }
}
