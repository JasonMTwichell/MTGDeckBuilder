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

        [JsonProperty("codeV3")]
        public string? CodeV3 { get; set; }

        [JsonProperty("isForeignOnly")]
        public bool? IsForeignOnly { get; set; }

        [JsonProperty("isFoilOnly")]
        public bool? IsFoilOnly { get; set; }

        [JsonProperty("isNonFoilOnly")]
        public bool? IsNonFoilOnly { get; set; }

        [JsonProperty("isOnlineOnly")]
        public bool? IsOnlineOnly { get; set; }

        [JsonProperty("isPaperOnly")]
        public bool? IsPaperOnly { get; set; }

        [JsonProperty("isPartialPreview")]
        public bool? IsPartialPreview { get; set; }

        [JsonProperty("keyruneCode")]
        public string? KeyruneCode { get; set; }

        [JsonProperty("mcmId")]
        public int? McmId { get; set; }

        [JsonProperty("mcmIdExtras")]
        public int? McmIdExtras { get; set; }

        [JsonProperty("mcmName")]
        public int? McmName { get; set; }

        [JsonProperty("mtgoCode")]
        public string? MtgoCode { get; set; }

        [JsonProperty("languages")]
        public string[]? Languages { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("parentCode")]
        public string? ParentCode { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("sealedProduct")]
        public MTGJsonAllPrintingsSetSealedProduct[]? SealedProduct { get; set; }

        [JsonProperty("tcgplayerGroupId")]
        public int? TcgplayerGroupId { get; set; }

        [JsonProperty("tokens")]
        public MTGJsonAllPrintingsSetTokens[]? Tokens { get; set; }

        [JsonProperty("totalSetSize")]
        public int? TotalSetSize { get; set; }

        [JsonProperty("translations")]
        public MTGJsonAllPrintingsSetTranslations? Translations { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
