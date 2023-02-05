namespace MTGDeckBuilder.EF.Entities
{
    public record SetCardRulingData
    {
        public int pkSetCardRuling { get; set; }
        public int? fkSetCard { get; set; }
        public string? RulingDate { get; set; }
        public string? RulingText { get; set; }

        public virtual SetCardData SetCard { get; set; }
    }
}
