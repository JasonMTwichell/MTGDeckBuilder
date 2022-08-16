using Newtonsoft.Json;
using System;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonMeta
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
