using Newtonsoft.Json;
using System;

namespace MTGDeckBuilder.MTGJson.Parse
{
    public class MTGJsonAllPrintingsMeta
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
