using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class UserDeckCardData
    {
        public int fkUserDeck { get; set; }
        public string fkCard { get; set; }
        
        public virtual UserDeckData UserDeck { get; set; }
        public virtual CardData Card { get; set; }
    }
}
