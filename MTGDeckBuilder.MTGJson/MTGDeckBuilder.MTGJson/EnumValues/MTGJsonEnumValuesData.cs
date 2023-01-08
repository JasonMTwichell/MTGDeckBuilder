using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesData
    {
        [JsonProperty("card")]
        public MTGJsonEnumValuesCard? CardEnumValues { get; set; }

        [JsonProperty("deck")]
        public MTGJsonEnumValuesDeck? DeckEnumValues { get; set; }

        [JsonProperty("foreignData")]
        public MTGJsonEnumValuesForeignData? ForeignDataEnumValues { get; set; }

        [JsonProperty("keywords")]
        public MTGJsonEnumValuesKeywords? KeywordEnumValues { get; set; }

        [JsonProperty("set")]
        public MTGJsonEnumValuesSetValues? SetEnumValues { get; set; }

        [JsonProperty("tcgplayerSkus")]
        public MTGJsonEnumValuesTcgPlayerSkus? TcgPlayerSkuValues { get; set; }
    }
}

