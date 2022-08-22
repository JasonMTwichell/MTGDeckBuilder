namespace MTGDeckBuilder.EF.Entities
{
    public class CardSubTypeData
    {
        public string fkCard { get; set; }
        public string fkSubType { get; set; }

        public virtual CardData Card { get; set; }
        public virtual SubTypeData SubType { get; set; }
    }
}
