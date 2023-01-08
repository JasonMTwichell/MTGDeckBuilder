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
        public ParsedEnumValuesMeta? Meta { get; set; }
        public ParsedEnumValuesData? Data { get; set; }
    }
}
