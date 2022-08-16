﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.Core.Domain
{
    public class Card
    {
        public string AsciiName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Layout { get; set; }
        public string Side { get; set; }
        public string ManaCost { get; set; }
        public double ManaValue { get; set; }
        public string Loyalty { get; set; }
        public int? HandModifier { get; set; }
        public int? LifeModifier { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string[] Printings { get; set; }
        public string[] Keywords { get; set; }
        public string[] Types { get; set; }
        public string[] SuperTypes { get; set; }
        public string[] SubTypes { get; set; }
        public string[] ColorIdentity { get; set; }
        public string[] Colors { get; set; }
        public bool IsFunny { get; set; } 
        public bool IsReserved { get; set; } 
        public bool HasAlternateDeckLimit { get; set; } 
        public Ruling[]? Rulings { get; set; }
        public Legality[]? Legalities { get; set; }
        public PurchaseInformation[]? PurchaseInformation { get; set; }
    }
}
