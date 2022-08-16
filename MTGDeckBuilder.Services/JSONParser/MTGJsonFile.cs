using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonFile
    {
        [JsonProperty("meta")]
        public MTGJsonMeta Meta { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, List<MTGJsonCard>> Cards { get; set; }
    }
}
