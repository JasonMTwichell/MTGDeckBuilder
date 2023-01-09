using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class MetaData
    {
        public int? pkMeta { get; set; }
        public DateTime MetaDate { get; set; }
        public string Version { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
