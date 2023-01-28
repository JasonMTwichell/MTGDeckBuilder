namespace MTGDeckBuilder.Core.Domain
{
    public record Card
    {
        public int? CardID { get; set; }
        public int SetID { get; set; }
        public string? Artist { get; set; }
        public string? BorderColor { get; set; }
        public double? ConvertedManaCost { get; set; }
        public int? EdhrecRank { get; set; }
        public string? FrameVersion { get; set; }
        public bool? HasFoil { get; set; }
        public bool? HasNonFoil { get; set; }
        public bool? IsReprint { get; set; }
        public string? Language { get; set; }
        public string? Layout { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? OriginalText { get; set; }
        public string? OriginalType { get; set; }
        public string? Rarity { get; set; }
        public string? SetCode { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string? UUID { get; set; }
        public string? CardKingdom { get; set; }
        public string? Tcgplayer { get; set; }        
        public IEnumerable<CardType>? Types { get; set; }
        public IEnumerable<Supertype>? Supertypes { get; set; }
        public IEnumerable<Subtype>? Subtypes { get; set; }
        public IEnumerable<CardPrinting>? Printings { get; set; }
        public IEnumerable<Keyword>? Keywords { get; set; }
        public IEnumerable<Finish>? Finishes { get; set; }
        public IEnumerable<Color>? Colors { get; set; }
        public IEnumerable<ColorIdentity>? ColorIdentity { get; set; }
        public IEnumerable<BoosterType>? BoosterTypes { get; set; }
        public IEnumerable<Availability>? Availability { get; set; }
        public IEnumerable<CardLegality>? CardLegalities { get; set; }
        public IEnumerable<CardRuling>? Rulings { get; set; }
        public IEnumerable<CardForeignData>? ForeignData { get; set; }
    }
}
