using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.Meta
{
    internal class MTGJsonMeta
    {
        [JsonProperty("data.date")]
        public DateTime Date { get; set; }

        [JsonProperty("data.version")]
        public string Version { get; set; }
    }
}
