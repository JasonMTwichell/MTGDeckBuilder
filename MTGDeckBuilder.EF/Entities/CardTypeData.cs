namespace MTGDeckBuilder.EF.Entities
{
    public class CardTypeData
    {
        public int? pkCardType { get; set; }
        public string CardTypeDescription { get; set; }

        public virtual ICollection<SetCardData> SetCards { get; set; }
    }
}
