using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardColorIdentityData
    {
        public int fkCard { get; set; }
        public int fkColorIdentity { get; set; }

        public virtual CardData Card { get; set; }
        public virtual ColorIdentityData ColorIdentity { get; set; }
    }
}
