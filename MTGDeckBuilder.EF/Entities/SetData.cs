using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class SetData
    {
        public int pkSet { get; set; } // pk
        public string SetCode { get; set; } // unique index
        public string SetName { get; set; } // unique index
        public int BaseSetSize { get; set; }
        public int TotalSetSize { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SetType { get; set; } 

        public virtual ICollection<CardData> SetCards { get; set; }
    }
}
