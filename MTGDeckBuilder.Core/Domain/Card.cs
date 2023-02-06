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

        public string? CardKingdomPurchaseUrl { get; set; }
        public string? CardKingdomEtchedPurchaseUrl { get; set; }
        public string? CardKingdomFoilPurchaseUrl { get; set; }
        public string? CardMarketPurchaseUrl { get; set; }
        public string? TcgplayerPurchaseUrl { get; set; }
        public string? TcgplayerEtchedPurchaseUrl { get; set; }

        public string? CardKingdomEtchedId { get; set; }
        public string? CardKingdomFoilId { get; set; }
        public string? CardKingdomId { get; set; }
        public string? CardsphereId { get; set; }
        public string? McmId { get; set; }
        public string? McmMetaId { get; set; }
        public string? MtgArenaId { get; set; }
        public string? MtgoFoilId { get; set; }
        public string? MtgoId { get; set; }
        public string? MtgjsonV4Id { get; set; }
        public string? MultiverseId { get; set; }
        public string? ScryfallId { get; set; }
        public string? ScryfallOracleId { get; set; }
        public string? ScryfallIllustrationId { get; set; }
        public string? TcgplayerProductId { get; set; }
        public string? TcgPlayerEtchedProductId { get; set; }

        public bool? IsBrawlFormatLegal { get; set; }
        public bool? IsCommanderFormatLegal { get; set; }
        public bool? IsDuelFormatLegal { get; set; }
        public bool? IsFutureFormatLegal { get; set; }
        public bool? IsFrontierFormatLegal { get; set; }
        public bool? IsGladiatorFormatLegal { get; set; }
        public bool? IsHistoricFormatLegal { get; set; }
        public bool? IsHistoricBrawlFormatLegal { get; set; }
        public bool? IsLegacyFormatLegal { get; set; }
        public bool? IsModernFormatLegal { get; set; }
        public bool? IsOldschoolFormatLegal { get; set; }
        public bool? IsPauperFormatLegal { get; set; }
        public bool? IsPauperCommanderFormatLegal { get; set; }
        public bool? IsPennyFormatLegal { get; set; }
        public bool? IsPioneerFormatLegal { get; set; }
        public bool? IsPremodernFormatLegal { get; set; }
        public bool? IsStandardFormatLegal { get; set; }
        public bool? IsVintageFormatLegal { get; set; }

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
        public IEnumerable<CardRuling>? Rulings { get; set; }
        public IEnumerable<CardForeignData>? ForeignData { get; set; }
    }
}
