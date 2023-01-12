using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IFileTreatment
    {
        Task TreatFile(string inputFilePath, string? outputPath);
    }
}
