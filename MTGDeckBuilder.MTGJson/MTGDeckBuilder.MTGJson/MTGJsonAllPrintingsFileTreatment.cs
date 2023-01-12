using MTGDeckBuilder.MTGJson.AllPrintings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace MTGDeckBuilder.MTGJson
{
    public class MTGJsonAllPrintingsFileTreatment : IMTGJsonFileTreatment
    {
        public async Task TreatFile(string filePath)
        {
            Stopwatch watch = new Stopwatch();   
            watch.Start();
            using (StreamReader streamReader = new StreamReader(filePath))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                string parentDirectory = Path.GetDirectoryName(filePath) ?? filePath;
                string setsDirectoryPath = Path.Combine(parentDirectory, "Sets");                
                if (!Directory.Exists(setsDirectoryPath))
                {
                    Directory.CreateDirectory(setsDirectoryPath);
                }

                int depth = -1;
                string setFilePath = string.Empty;
                JsonSerializer serializer = new JsonSerializer();
                while (true)
                {                  
                    if (!reader.Read())
                    {
                        break;
                    }

                    if (reader.TokenType == JsonToken.PropertyName && (string?)reader.Value == "data")
                    {
                        depth = reader.Depth + 1;
                    }

                    if (reader.TokenType == JsonToken.PropertyName && reader.Depth == depth)
                    {
                        string setCode = (string?)reader.Value ?? string.Empty;
                        setFilePath = Path.Combine(setsDirectoryPath, string.Format("{0}.json", setCode));
                    }

                    // could work this off regex against the JToken path, but this is more intuitive to me
                    if (reader.TokenType == JsonToken.StartObject && reader.Depth == depth)
                    {                        
                        using(StreamWriter writer = new StreamWriter(setFilePath))
                        using(JsonTextWriter textWriter = new JsonTextWriter(writer))
                        {
                            textWriter.WriteToken(reader);
                        }
                    }
                }

                Console.WriteLine(watch.Elapsed.ToString());
               // return Task.CompletedTask;
            }
        }
    }
}
