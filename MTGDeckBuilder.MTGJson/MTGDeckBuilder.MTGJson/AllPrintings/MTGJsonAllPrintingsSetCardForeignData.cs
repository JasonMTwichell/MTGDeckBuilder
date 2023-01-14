using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public class MTGJsonAllPrintingsSetCardForeignData
    {
        [JsonProperty("flavorText")]
        public string? FlavorTest { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("multiverseId")]
        public string? MultiverseId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
