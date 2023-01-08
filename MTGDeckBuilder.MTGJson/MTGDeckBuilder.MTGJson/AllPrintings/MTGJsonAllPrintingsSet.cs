using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{
    internal class MTGJsonAllPrintingsSet
    {
        [JsonProperty("baseSetSize")]
        public int? BaseSetSize { get; set; }

        [JsonProperty("block")]
        public string? Block { get; set; }

        [JsonProperty("cards")]
        public MTGJsonAllPrintingsCard[]? Cards { get; set; }
        
        [JsonProperty("cardsphereSetId")]
        public int? CardsphereSetId { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("isNonFoilOnly")]
        public bool? IsFoilOnly { get; set; }

        [JsonProperty("isNonFoilOnly")]
        public bool? IsNonFoilOnly { get; set; }

        [JsonProperty("isOnlineOnly")]
        public bool? IsOnlineOnly { get; set; }

        [JsonProperty("keyruneCode")]
        public string? KeyruneCode { get; set; }

        [JsonProperty("languages")]
        public string[]? Languages { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
        
        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("tcgplayerGroupId")]
        public int? TcgplayerGroupId { get; set; }
        
        [JsonProperty("totalSetSize")]
        public int? TotalSetSize { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
