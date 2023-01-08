using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValues
    {
        [JsonProperty("meta")]
        public MTGJsonEnumValuesMeta? MetaData { get; set; }

        [JsonProperty("data.card")]
        public MTGJsonEnumValuesCard? CardEnumValues { get; set; }

        [JsonProperty("data.deck")]
        public MTGJsonEnumValuesDeck? DeckEnumValues { get; set; }

        [JsonProperty("deck.foreignData")]
        public MTGJsonEnumValuesForeignData? ForeignDataEnumValues { get; set; }

        [JsonProperty("deck.keywords")]
        public MTGJsonEnumValuesKeywords? KeywordEnumValues { get; set; }

        [JsonProperty("deck.set")]
        public MTGJsonEnumValuesSetValues? SetEnumValues { get; set; }

        [JsonProperty("deck.tcgplayerSkus")]
        public MTGJsonEnumValuesTcgPlayerSkus? TcgPlayerSkuValues { get; set; }

    }
}

