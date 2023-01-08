using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.EnumValues
{
    internal class MTGJsonEnumValuesKeywords
    {
        [JsonProperty("abilityWords")]
        public string[]? AbilityWords { get; set; }

        [JsonProperty("keywordAbilities")]
        public string[]? KeywordAbilities { get; set; }
        
        [JsonProperty("keywordActions")]
        public string[]? KeywordActions { get; set; }
    }

}

