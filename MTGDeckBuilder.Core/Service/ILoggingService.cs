using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface ILoggingService
    {
        Task Log(string logMessage);
    }
}
