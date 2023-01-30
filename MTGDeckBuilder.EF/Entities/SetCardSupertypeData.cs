namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardSupertypeData
    {
        public int fkSetCard { get; set; }
        public int fkSupertype { get; set; }
        public SetCardData SetCard { get; set; }
        public SupertypeData Supertype { get; set; }
    }
}
