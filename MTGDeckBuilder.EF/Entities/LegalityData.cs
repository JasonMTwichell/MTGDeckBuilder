namespace MTGDeckBuilder.EF.Entities
{
    public class LegalityData
    {
        public int pkLegality { get; set; }      
        public string Format { get; set; }     
        
        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardLegalityData> CardLegalities { get; set; }
        public virtual ICollection<UserDeckData> UserDecks { get; set; }
    }
}