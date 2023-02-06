namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsSetCardLeadershipSkills
    {
        public bool? IsBrawlLegal { get; set; }
        public bool? IsCommanderLegal { get; set; }
        public bool? IsOathbreakerLegal { get; set; }
    }
}
