using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class AvailabilityData
    {
        public int? pkAvailability { get; set; }
        public string AvailabilityDescription { get; set; }
    }
}
