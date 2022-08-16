using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class ColorData
    {
        public int pkColor { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardData> CardIdentities { get; set; }
    }
}
