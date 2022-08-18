namespace MTGDeckBuilder.EF.Entities
{
    public class LegalityData
    {
        public int pkLegality { get; set; }
        public int fkCard { get; set; }
        public string Format { get; set; }
        public string Status { get; set; }

        public virtual CardData Card { get; set; }
    }
}