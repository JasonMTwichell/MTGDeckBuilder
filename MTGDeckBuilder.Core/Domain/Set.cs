using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class Set
    {
        public int? SetID { get; set; } 
        public string SetCode { get; set; }
        public string SetName { get; set; }
        public int BaseSetSize { get; set; }
        public int TotalSetSize { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SetType { get; set; }
    }
}
