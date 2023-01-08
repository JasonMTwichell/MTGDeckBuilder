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
        public MTGJsonEnumValuesMeta? Meta { get; set; }

        [JsonProperty("data")]
        public MTGJsonEnumValuesData? Data { get; set; }
    }
}

