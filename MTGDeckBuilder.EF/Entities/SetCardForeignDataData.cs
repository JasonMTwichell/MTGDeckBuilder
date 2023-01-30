namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardForeignDataData
    {
        public int? pkSetCardForeignData { get; set; }
        public int? fkSetCard { get; set; }
        public string? FaceName { get; set; }
        public string? Language { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? FlavorText { get; set; }
        public string? MultiverseID { get; set; }
        public string? Text { get; set; }
    }
}
