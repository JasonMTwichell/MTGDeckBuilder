using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class ColorData
    {
        public string Color { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
    }
}
