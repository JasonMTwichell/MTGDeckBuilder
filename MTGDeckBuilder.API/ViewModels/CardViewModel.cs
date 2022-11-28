namespace MTGDeckBuilder.API.ViewModels
{
    public class CardViewModel
    {
        public int CardID { get; set; }
        public string CardUUID { get; set; }
        public string ManaCost { get; set; }
        public double ConvertedManaCost { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string SuperType { get; set; }
        public string SubType { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public int? Loyalty { get; set; }
        public bool HasPowerToughness { get; set; }
        public bool HasLoyalty { get; set; }
    }
}
