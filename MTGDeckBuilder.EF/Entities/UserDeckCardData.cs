using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckCardData
    {
        public int pkUserDeckCard { get; set; }
        public int fkUserDeck { get; set; }
        public string CardUUID { get; set; }
        public int NumCopies { get; set; }
        
        public virtual UserDeckData UserDeck { get; set; }
        public virtual CardData CardData { get; set; }
    }
}
