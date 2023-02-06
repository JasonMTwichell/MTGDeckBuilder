using MTGDeckBuilder.MTGJson.AllPrintings;
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
        public bool? IsFoilOnly { get; set; }
        public bool? IsNonFoilOnly { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public string? KeyruneCode { get; set; }
        public string[]? Languages { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? TcgplayerGroupId { get; set; }
        public int? TotalSetSize { get; set; }
        public string? Type { get; set; }
    }
}
