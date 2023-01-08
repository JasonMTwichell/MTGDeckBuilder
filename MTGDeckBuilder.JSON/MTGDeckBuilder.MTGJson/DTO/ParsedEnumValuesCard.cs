namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedEnumValuesCard
    {
        public string[]? Availabilities { get; set; }
        public string[]? BoosterTypes { get; set; }
        public string[]? BorderColors { get; set; }
        public string[]? ColorIdentities { get; set; }
        public string[]? ColorIndicators { get; set; }
        public string[]? Colors { get; set; }
        public string[]? DuelDecks { get; set; }
        public string[]? Finishes { get; set; }
        public string[]? FrameEffects { get; set; }
        public string[]? FrameVersions { get; set; }
        public string[]? Languages { get; set; }
        public string[]? Layouts { get; set; }
        public string[]? PromoTypes { get; set; }
        public string[]? Rarities { get; set; }
        public string[]? SecurityStamps { get; set; }
        public string[]? Sides { get; set; }
        public string[]? Subtypes { get; set; }
        public string[]? Supertypes { get; set; }
        public string[]? Types { get; set; }
        public string[]? Watermarks { get; set; }
    }
}
