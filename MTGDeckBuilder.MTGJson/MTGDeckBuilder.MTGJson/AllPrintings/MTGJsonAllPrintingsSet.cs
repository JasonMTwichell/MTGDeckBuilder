using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.AllPrintings
{

    public class MTGJsonAllPrintingsSet
    {
        [JsonProperty("baseSetSize")]
        public int? BaseSetSize { get; set; }

        [JsonProperty("block")]
        public string? Block { get; set; }        

        [JsonProperty("cards")]
        public MTGJsonAllPrintingsSetCard[]? Cards { get; set; }

        [JsonProperty("cardsphereSetId")]
        public int? CardsphereSetId { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("isFoilOnly")]
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
        public string? ReleaseDate { get; set; }

        [JsonProperty("sealedProduct")]
        public MTGJsonAllPrintingsSetSealedProduct[]? SealedProduct { get; set; }

        [JsonProperty("tcgplayerGroupId")]
        public int? TcgplayerGroupId { get; set; }

        [JsonProperty("tokens")]
        public string[]? Tokens { get; set; }

        [JsonProperty("totalSetSize")]
        public int? TotalSetSize { get; set; }

        [JsonProperty("translations")]
        public MTGJsonAllPrintingsSetTranslations? Translations { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
