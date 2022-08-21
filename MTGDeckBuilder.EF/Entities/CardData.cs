using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardData
    {
        public int pkCard { get; set; }
        public string? Name { get; set; }
        public string? AsciiName { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string? Layout { get; set; }
        public string? Side { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public string? Loyalty { get; set; }
        public int? HandModifier { get; set; }
        public int? LifeModifier { get; set; }
        public string? Power { get; set; }
        public string? Toughness { get; set; }

        public bool? IsFunny { get; set; }
        public bool? IsReserved { get; set; }
        public bool? HasAlternateDeckLimit { get; set; }


        // NAVIGATION
        public virtual ICollection<ColorData> Colors { get; set; }
        public virtual ICollection<CardColorData> CardColors { get; set; }

        public virtual ICollection<ColorIdentityData> ColorIdentities { get; set; }
        public virtual ICollection<CardColorIdentityData> CardColorIdentities { get; set; }

        public virtual ICollection<TypeData> Types { get; set; }
        public virtual ICollection<CardTypeData> CardTypes { get; set; }

        public virtual ICollection<SuperTypeData> SuperTypes { get; set; }
        public virtual ICollection<CardSuperTypeData> CardSuperTypes { get; set; }

        public virtual ICollection<SubTypeData> SubTypes { get; set; }
        public virtual ICollection<CardSubTypeData> CardSubTypes { get; set; }

        public virtual ICollection<KeywordData> Keywords { get; set; }
        public virtual ICollection<CardKeywordData> CardKeywords { get; set; }

        public virtual ICollection<LegalityData> Legalities { get; set; }
        public virtual ICollection<CardLegalityData> CardLegalities { get; set; }

        public virtual ICollection<UserDeckData> UserDecks { get; set; }
        public virtual ICollection<UserDeckCardData> UserDeckCardData { get; set; }
        
        public virtual ICollection<UserDeckSideboardData> UserDeckSideboards { get; set; }
        public virtual ICollection<UserDeckSideboardCardData> UserDeckSideboardCards { get; set; }

        public virtual ICollection<PurchaseInformationData> PurchaseInformation { get; set; }

    }
}
