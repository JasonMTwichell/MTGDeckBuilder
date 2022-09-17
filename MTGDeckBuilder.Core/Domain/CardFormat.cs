using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class CardFormat
    {
        public int? FormatID { get; set; }
        public int? CardID { get; set; }
        public bool IsLegal { get; set; }
    }
}
