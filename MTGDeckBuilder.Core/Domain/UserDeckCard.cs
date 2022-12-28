using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class UserDeckCard
    {
        public int UserDeckID { get; set; }
        public int NumCopiesInDeck { get; set; }
        public Card Card { get; set; }
    }
}
