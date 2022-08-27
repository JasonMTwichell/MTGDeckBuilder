using Microsoft.Extensions.Configuration;
using MTGDeckBuilder.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder
{
    public class MTGDeckBuilderConfiguration : IMTGConfiguration
    {
        IConfiguration _cfg;
        public MTGDeckBuilderConfiguration()
        {
            _cfg = new ConfigurationBuilder()                                               
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string GetConfigurationValue(string key)
        {
            return GetFromEnvironment(key) ?? _cfg.GetValue<string>(key);
        }

        private string GetFromEnvironment(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
