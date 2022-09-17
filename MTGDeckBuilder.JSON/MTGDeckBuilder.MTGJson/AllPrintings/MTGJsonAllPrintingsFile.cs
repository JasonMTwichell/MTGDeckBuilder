using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.MTGJson.Parse
{
    public class MTGJsonAllPrintingsFile
    {
        [JsonProperty("meta")]
        public MTGJsonAllPrintingsMeta Meta { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, MTGJsonAllPrintingsSet> Sets { get; set; }
    }
}
