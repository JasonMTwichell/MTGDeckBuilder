namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedFormat
    {
        public int? FormatID { get; set; }
        public string FormatName { get; set; }
        public string Status { get; set; }
    }
}
