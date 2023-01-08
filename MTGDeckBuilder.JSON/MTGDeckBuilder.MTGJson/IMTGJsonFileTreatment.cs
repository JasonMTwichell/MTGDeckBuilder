using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson
{
    public interface IMTGJsonFileTreatment
    {
        Task TreatFile(string filePath);
    }
}
