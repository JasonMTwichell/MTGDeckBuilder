using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record Set
    {
        public int? SetID { get; set; }
        public int? BaseSetSize { get; set; }
        public string? Block { get; set; }
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
        public IEnumerable<Card>? Cards { get; set; }
    }
}
