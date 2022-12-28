using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record struct UserDeckSideboardCardsCreate
    {
        public int UserDeckID { get; set; }
        public string CardUUID { get; set; }
        public int NumCopies { get; set; }
    }
}
