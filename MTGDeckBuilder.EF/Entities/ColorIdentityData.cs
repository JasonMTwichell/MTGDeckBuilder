using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class ColorIdentityData
    {
        public int pkColorIdentity { get; set; }
        public string ColorIdentityName { get; set; }

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardColorIdentityData> CardColorIdentities { get; set; }
    }
}
