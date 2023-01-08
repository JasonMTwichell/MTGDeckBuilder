namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedEnumValuesData
    {
        public ParsedEnumValuesCard? CardEnumValues { get; set; }
        public ParsedEnumValuesDeck? DeckEnumValues { get; set; }
        public ParsedEnumValuesForeignData? ForeignDataEnumValues { get; set; }
        public ParsedEnumValuesKeywords? KeywordEnumValues { get; set; }
        public ParsedEnumValuesSetValues? SetEnumValues { get; set; }
        public ParsedEnumValuesTcgPlayerSkus? TcgPlayerSkuValues { get; set; }
    }
}
