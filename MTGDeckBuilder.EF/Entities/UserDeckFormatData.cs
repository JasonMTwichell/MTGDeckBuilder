namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckFormatData
    {
        public int fkUserDeck { get; set; }
        public string Format { get; set; }

        public virtual FormatData DeckFormat { get; set; }
        public virtual UserDeckData Deck { get; set; }
    }
}
