using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.Services.JSONParser
{
    public class MTGJsonCard
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("asciiName")]
        public string AsciiName { get; set; }

        [JsonProperty("faceName")]
        public string FaceName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("manaCost")]
        public string ManaCost { get; set; }

        [JsonProperty("manaValue")]
        public double ManaValue { get; set; }

        [JsonProperty("loyalty")]
        public string Loyalty { get; set; }

        [JsonProperty("hand")]
        public int? HandModifier { get; set; }

        [JsonProperty("life")]
        public int? LifeModifier { get; set; }

        [JsonProperty("power")]
        public string Power { get; set; }

        [JsonProperty("toughness")]
        public string Toughness { get; set; }

        [JsonProperty("printings")]
        public string[] Printings { get; set; }

        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }

        [JsonProperty("superTypes")]
        public string[] SuperTypes { get; set; }

        [JsonProperty("subTypes")]
        public string[] SubTypes { get; set; }

        [JsonProperty("colorIdentity")]
        public string[] ColorIdentity { get; set; }

        [JsonProperty("colors")]
        public string[] Colors { get; set; }

        [JsonProperty("colorIndicator")]
        public string[] ColorIndicators { get; set; }

        [JsonProperty("rulings")]
        public List<MTGJsonRuling> Rulings { get; set; }

        [JsonProperty("isFunny")]
        public bool IsFunny { get; set; }

        [JsonProperty("isReserved")]
        public bool IsReserved { get; set; }

        [JsonProperty("hasAlternativeDeckLimit")]
        public bool HasAlternateDeckLimit { get; set; }

        [JsonProperty("legalities")]
        public Dictionary<string, string> Legalities { get; set; }
        
        [JsonProperty("purchaseUrls")]
        public Dictionary<string, string> PurchaseInformation { get; set; }

        [JsonProperty("identifiers")]
        public Dictionary<string, string> Identifiers { get; set; }

        [JsonProperty("faceManaValue")]
        public double FaceManaValue { get; set; }

        [JsonProperty("leadershipSkills")]
        public Dictionary<string, bool> LeadershipSkills { get; set; }
    }
}
