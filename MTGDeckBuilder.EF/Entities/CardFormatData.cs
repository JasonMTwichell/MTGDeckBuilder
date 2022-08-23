namespace MTGDeckBuilder.EF.Entities
{
    public class CardFormatData
    {
        public int fkCard { get; set; }
        public int fkFormat { get; set; }
        public bool IsLegal { get; set; }

        public virtual CardData Card { get; set; }
        public virtual FormatData Format { get; set; }
    }
}