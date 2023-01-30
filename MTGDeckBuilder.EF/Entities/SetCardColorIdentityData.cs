namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardColorIdentityData
    {
        public int fkSetCard { get; set; }
        public int fkColorIdentity { get; set; }
        public SetCardData SetCard { get; set; }
        public ColorIdentityData ColorIdentity { get; set; }
    }
}
