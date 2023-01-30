namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardAvailabilityData
    {
        public int fkSetCard { get; set; }
        public int fkAvailability { get; set; }
        public SetCardData SetCard { get; set; }
        public AvailabilityData AvailabilityData { get; set; }
    }
}
