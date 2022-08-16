using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class CardData
    {
        public int pkCard { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Layout { get; set; }
        public string Side { get; set; }
        public string ManaCost { get; set; }
        public double ManaValue { get; set; }
        public string? Loyalty { get; set; }
        public int? HandModifier { get; set; }
        public int? LifeModifier { get; set; }
        public string? Power { get; set; }
        public string? Toughness { get; set; }             
        
        public bool IsFunny { get; set; }
        public bool IsReserved { get; set; }
        public bool HasAlternateDeckLimit { get; set; }        


        // NAVIGATION
        public virtual ICollection<ColorData> Colors { get; set; }
        public virtual ICollection<ColorData> ColorIdentities { get; set; }
        public virtual ICollection<TypeData> Types { get; set; }
        public virtual ICollection<SuperTypeData> SuperTypes { get; set; }
        public virtual ICollection<SubTypeData> SubTypes { get; set; }
        public virtual ICollection<LegalityData> Legalities { get; set; }
        public virtual ICollection<PurchaseInformationData> PurchaseInformation { get; set; }
        public virtual ICollection<KeywordData> Keywords { get; set; }
    }
}
