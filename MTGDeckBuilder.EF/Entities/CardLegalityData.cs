namespace MTGDeckBuilder.EF.Entities
{
    public class CardLegalityData
    {
        public string fkCard { get; set; }
        public string fkLegality { get; set; }
        public bool IsLegal { get; set; }

        public virtual CardData Card { get; set; }
        public virtual LegalityData Legality { get; set; }
    }
}