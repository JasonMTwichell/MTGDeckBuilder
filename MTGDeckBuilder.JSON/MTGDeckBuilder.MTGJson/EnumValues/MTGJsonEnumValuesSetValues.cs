using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesSetValues 
    {
        [JsonProperty("type")]
        public string[]? Types { get; set; }
    }

}

