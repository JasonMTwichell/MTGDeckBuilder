using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class ColorData
    {
        public int pkColor { get; set; } // pk
        public string Color { get; set; } // unique index

        public virtual ICollection<CardData> Cards { get; set; }
    }
}
