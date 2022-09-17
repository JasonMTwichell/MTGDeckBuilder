using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.Core.Domain
{
    public class Card
    {
        public int? CardID { get; set; } 
        public int? SetID { get; set; } 
        public string UUID { get; set; } 
        public string? Name { get; set; }
        public string? AsciiName { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string? Layout { get; set; }
        public string? Side { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public int? Loyalty { get; set; }
        public int? HandModifier { get; set; }
        public int? LifeModifier { get; set; }
        public string? Power { get; set; }
        public string? Toughness { get; set; }
        public bool? IsFunny { get; set; }
        public bool? IsReserved { get; set; }
        public bool? HasAlternateDeckLimit { get; set; }        
        public string? FlavorText { get; set; }
        public string? Rarity { get; set; }
        public string? FaceName { get; set; }
        public string? NumberInSet { get; set; }

        public virtual Set Set { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<ColorIdentity> ColorIdentities { get; set; }
        public virtual ICollection<CardType> Types { get; set; }
        public virtual ICollection<SuperType> SuperTypes { get; set; }
        public virtual ICollection<SubType> SubTypes { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<CardFormat> CardFormats { get; set; }
        public virtual ICollection<PurchaseInformation> PurchaseInformation { get; set; }
    }
}
