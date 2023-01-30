namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardColorData
    {
        public int fkSetCard { get; set; }
        public int fkColor { get; set; }
        public SetCardData SetCard { get; set; }
        public ColorData Color { get; set; }
    }
}
