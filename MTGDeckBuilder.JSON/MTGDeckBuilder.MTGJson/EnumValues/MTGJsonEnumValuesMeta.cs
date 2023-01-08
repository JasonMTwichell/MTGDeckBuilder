using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesMeta
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

}

