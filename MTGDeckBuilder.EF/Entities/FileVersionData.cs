using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class FileVersionData
    {
        public int pkVersion { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
    }
}
