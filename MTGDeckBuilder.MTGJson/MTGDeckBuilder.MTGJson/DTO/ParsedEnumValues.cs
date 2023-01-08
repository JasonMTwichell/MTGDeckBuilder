using MTGDeckBuilder.MTGJson.EnumValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedEnumValues
    {
        public ParsedEnumValuesMeta? MetaData { get; set; }
        public ParsedEnumValuesCard? CardEnumValues { get; set; }
        public ParsedEnumValuesDeck? DeckEnumValues { get; set; }
        public ParsedEnumValuesForeignData? ForeignDataEnumValues { get; set; }
        public ParsedEnumValuesKeywords? KeywordEnumValues { get; set; }
        public ParsedEnumValuesSetValues? SetEnumValues { get; set; }
        public ParsedEnumValuesTcgPlayerSkus? TcgPlayerSkuValues { get; set; }
    }
}
