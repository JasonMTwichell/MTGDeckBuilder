using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonSet
    {
        [JsonProperty("name")]
        public string SetName { get; set; }

        [JsonProperty("code")]
        public string SetCode { get; set; }

        [JsonProperty("baseSetSize")]
        public int BaseSetSize { get; set; }

        [JsonProperty("totalSetSize")]
        public int TotalSetSize { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("type")]
        public string SetType { get; set; }

        [JsonProperty("cards")]
        public MTGJsonCard[] SetCards { get; set; }
    }
}
