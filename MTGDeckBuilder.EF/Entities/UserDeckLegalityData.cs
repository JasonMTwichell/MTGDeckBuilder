namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckLegalityData
    {
        public int fkUserDeck { get; set; }
        public string fkLegality { get; set; }

        public virtual UserDeckData Deck { get; set; }
        public virtual LegalityData Legality { get; set; }
    }
}
