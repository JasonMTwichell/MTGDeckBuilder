namespace MTGDeckBuilder.EF.Entities
{
    public class LegalityData
    {
        public string Legality { get; set; } //pk
        
        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardLegalityData> CardLegalities { get; set; }
        public virtual ICollection<UserDeckData> UserDecks { get; set; }
    }
}