using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    public record MTGJsonAllPrintingsSetCardLeadershipSkills
    {
        [JsonProperty("brawl")]
        public bool? IsBrawlLegal { get; set; }

        [JsonProperty("commander")]
        public bool? IsCommanderLegal { get; set; }

        [JsonProperty("oathbreaker")]
        public bool? IsOathbreakerLegal { get; set; }
    }
}
