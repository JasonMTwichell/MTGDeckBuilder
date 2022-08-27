using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IMTGConfiguration
    {
        string GetConfigurationValue(string key);
    }
}
