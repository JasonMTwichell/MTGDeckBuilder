using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record Meta
    {
        public int? MetaID { get; set; }
        public DateTime MetaDate { get; set; }
        public string Version { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
