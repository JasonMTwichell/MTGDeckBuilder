namespace MTGDeckBuilder.EF.Entities
{
    public class CardSubTypeData
    {
        public int fkCard { get; set; }
        public int fkSubType { get; set; }

        public virtual CardData Card { get; set; }
        public virtual SubTypeData SubType { get; set; }
    }
}
