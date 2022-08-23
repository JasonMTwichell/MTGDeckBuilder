using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardColorData
    {
        public string fkCard { get; set; }
        public string fkColor { get; set; }

        public virtual CardData Card { get; set; }
        public virtual ColorData Color { get; set; }
    }
}
