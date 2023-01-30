namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardSubtypeData
    {
        public int fkSetCard { get; set; }
        public int fkSubtype { get; set; }
        public SetCardData SetCard { get; set; }
        public SubtypeData Subtype { get; set; }
    }
}
