using MTGDeckBuilder.MTGJson.AllPrintings;
using Newtonsoft.Json;
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

    public class MTGJsonAllPrintingsFileTreatment : IMTGJsonFileTreatment
    {
        public Task TreatFile(string filePath)
        {
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
                string setCode = string.Empty;
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
                        setCode = (string?)reader.Value ?? string.Empty;
                    }

                    // could work this off regex against the JToken path, but this is more intuitive to me
                    if (reader.TokenType == JsonToken.StartObject && reader.Depth == depth)
                    {
                        // TODO: would be nice if we didnt have to serialize just to immediately deserialize, but finding the string content seems impossible
                        MTGJsonAllPrintingsSet set = serializer.Deserialize<MTGJsonAllPrintingsSet>(reader) ?? throw new Exception("Unable to deserialize set from JToken.");
                        string setFilePath = Path.Combine(setsDirectoryPath, string.Format("{0}.json", setCode));
                        string serializedSet = JsonConvert.SerializeObject(set);
                        File.WriteAllText(setFilePath, serializedSet);
                    }
                }

                return Task.CompletedTask;
            }
        }
    }
}
