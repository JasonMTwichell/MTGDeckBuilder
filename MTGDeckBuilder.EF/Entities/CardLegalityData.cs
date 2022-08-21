namespace MTGDeckBuilder.EF.Entities
{
    public class CardLegalityData
    {
        public int fkCard { get; set; }
        public int fkLegality { get; set; }
        public bool IsLegal { get; set; }

        public virtual CardData Card { get; set; }
        public virtual LegalityData Legality { get; set; }
    }
}