using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.DbUp;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using MTGDeckBuilder.MTGJson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace MTGDeckBuilder
{
    class Program
    {
        private static IUnityContainer _container;
        private static IMTGDeckBuilderRepository _repo;
        private static IMTGConfiguration _cfg;        
        static async Task Main(string[] args)
        {
            _container = IoCBootstrapper.BootstrapIoC();
            _repo = _container.Resolve<IMTGDeckBuilderRepository>();
            _cfg = _container.Resolve<IMTGConfiguration>();
            
            string dbPath = _cfg.GetConfigurationValue("MTG_DB_PATH");
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts(dbPath);            
            
            IMTGJsonParser parser = new MTGJsonParser();
            string mtgJsonFilePath = _cfg.GetConfigurationValue("MTG_JSON_FILE_PATH");
            ParsedAllPrintingsFile allPrintingsFile = await parser.ParseAllPrintingsFile(mtgJsonFilePath);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            
        }        
    }
}
