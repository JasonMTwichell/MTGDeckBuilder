using MTGDeckBuilder.Core.Domain;

namespace MTGDeckBuilder.Core.DTO
{
    public class CardSearchCriteria
    {
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Format> Formats { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<CardType> Types { get; set; }
        public IEnumerable<SuperType> SuperTypes { get; set; }
        public IEnumerable<SubType> SubTypes { get; set; }
        public IEnumerable<Keyword> Keywords { get; set; }
    }
}
