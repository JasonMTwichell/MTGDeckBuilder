using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckData
    {
        public int pkUserDeck { get; set; }
        public string DeckName { get; set; }
        public string DeckDescription { get; set; }

        public virtual UserDeckSideboardData SideBoard { get; set; }
        public virtual ICollection<CardData> Cards { get; set; }        
        public virtual ICollection<LegalityData> Legalities { get; set; }
    }
}
