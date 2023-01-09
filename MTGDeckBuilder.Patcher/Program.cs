using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.DbUp;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using MTGDeckBuilder.MTGJson;
using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.Patcher;
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
        private static IMTGDeckBuilderDbPatcher _patcher;
        static async Task Main(string[] args)
        {
            _container = IoCBootstrapper.BootstrapIoC();
            //_repo = _container.Resolve<IMTGDeckBuilderRepository>();
            _cfg = _container.Resolve<IMTGConfiguration>();
            _patcher = _container.Resolve<IMTGDeckBuilderDbPatcher>();
            
            // run dbup scripts
            string dbPath = _cfg.GetConfigurationValue("MTG_DB_PATH");
            MTGEmbeddedScriptsProvider.ExecuteDbUpScripts(dbPath);            
            
            // patch reference data
            IMTGJsonParser parser = new MTGJsonParser();
            string mtgJsonEnumValuesPath = _cfg.GetConfigurationValue("MTG_JSON_ENUMVALUES_FILEPATH");
            ParsedEnumValues parsedEnumValues = await parser.ParseEnumValues(mtgJsonEnumValuesPath);
            await _patcher.PatchReferenceData(new PatchReferenceDataCommand
            {
                Availabilities = parsedEnumValues.Data.CardEnumValues.Availabilities.Select(a => new Availability
                {
                    AvailabilityDescription = a 
                }).ToArray()
            });
            

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        }        
    }
}
