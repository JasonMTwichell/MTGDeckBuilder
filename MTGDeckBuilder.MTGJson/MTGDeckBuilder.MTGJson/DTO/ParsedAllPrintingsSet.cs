using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsSet
    {
        public int? BaseSetSize { get; set; }
        public string? Block { get; set; }
        public ParsedAllPrintingsSetCard[]? Cards { get; set; }
        public int? CardsphereSetId { get; set; }
        public string? Code { get; set; }
        public string? CodeV3 { get; set; }
        public bool? IsForeignOnly { get; set; }
        public bool? IsFoilOnly { get; set; }
        public bool? IsNonFoilOnly { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public bool? IsPaperOnly { get; set; }
        public bool? IsPartialPreview { get; set; }
        public string? KeyruneCode { get; set; }
        public int? McmId { get; set; }
        public int? McmIdExtras { get; set; }
        public int? McmName { get; set; }
        public string? MtgoCode { get; set; }
        public string[]? Languages { get; set; }
        public string? Name { get; set; }
        public string? ParentCode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? TcgplayerGroupId { get; set; }
        public ParsedAllPrintingsSetToken[]? Tokens { get; set; }
        public ParsedAllPrintingsSetSealedProduct? SealedProduct { get; set; }
        public int? TotalSetSize { get; set; }
        public ParsedAllPrintingsSetTranslations? Translations { get; set; }
        public string? Type { get; set; }
    }
}
