using Newtonsoft.Json;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonRuling
    {
        [JsonProperty("date")]
        public string RulingDate { get; set; }

        [JsonProperty("text")]
        public string RulingText { get; set; }
    }
}
