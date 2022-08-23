using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class ColorIdentityData
    {
        public string ColorIdentity { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardColorIdentityData> CardColorIdentities { get; set; }
    }
}
