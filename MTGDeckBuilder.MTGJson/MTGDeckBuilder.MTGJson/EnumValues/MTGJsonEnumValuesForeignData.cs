using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesForeignData
    {
        [JsonProperty("language")]
        public string[]? Languages { get; set; }
    }

}

