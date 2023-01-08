using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesTcgPlayerSkus
    {
        [JsonProperty("condition")]
        public string[]? Conditions { get; set; }

        [JsonProperty("finishes")]
        public string[]? Finishes { get; set; }

        [JsonProperty("language")]
        public string[]? Languages { get; set; }

        [JsonProperty("printing")]
        public string[]? Printings { get; set; }
    }

}

