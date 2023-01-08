using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesMeta
    {
        [JsonProperty("data.date")]
        public DateTime Date { get; set; }

        [JsonProperty("data.version")]
        public string Version { get; set; }
    }

}

