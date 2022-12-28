using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class UserDeck
    {
        public int UserDeckID { get; set; }
        public string DeckName { get; set; }
        public string? DeckDescription { get; set; }
        public DateTime DateCreated { get; set; }

        public IEnumerable<UserDeckCard>? SideBoard { get; set; }
        public IEnumerable<UserDeckCard> Cards { get; set; }
        public IEnumerable<Format> Formats { get; set; }
    }
}
