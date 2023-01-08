using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesDeck
    {
        [JsonProperty("type")]
        public string[]? Types { get; set; }
    }

}

