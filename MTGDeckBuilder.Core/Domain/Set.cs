namespace MTGDeckBuilder.Core.Domain
{
    public class Set
    {
        public int? SetID { get; set; }
        public string SetCode { get; set; }
        public string SetName { get; set; }
        public int BaseSetSize { get; set; }
        public int TotalSetSize { get; set; }
        public string ReleaseDate { get; set; }
        public string SetType { get; set; }
        public IEnumerable<Card> SetCards { get; set; }
    }
}
