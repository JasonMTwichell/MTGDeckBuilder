using MTGDeckBuilder.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Services
{
    //TODO: Move to log4net if needed
    public class ConsoleLoggingService : ILoggingService
    {
        public Task Log(string logMessage)
        {
            Console.WriteLine(logMessage);
            return Task.FromResult(0);
        }
    }
}
