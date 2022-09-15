using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.DbUp
{
    public static class MTGEmbeddedScriptsProvider
    {
        public static void ExecuteDbUpScripts(string connectionString)
        {
            string dbPath = $"Data Source={connectionString};";               
            
            var upgradeEngine = DeployChanges.To
                .SQLiteDatabase(dbPath)                   
                .WithScriptsEmbeddedInAssembly(typeof(MTGDBUpScripts).Assembly)
                .LogToConsole()                
                .Build();

            upgradeEngine.PerformUpgrade();            
        }
    }
}
