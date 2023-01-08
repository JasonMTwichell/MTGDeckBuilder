using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.MTGJson.Parse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson
{
    public class MTGJsonParser2 : IMTGJsonParser
    {
        public Task<ParsedAllPrintingsFile> ParseAllPrintingsFile(string filePath)
        {            
            using (StreamReader streamReader = new StreamReader(filePath))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                string parentDirectory = Path.GetDirectoryName(filePath);
                string setsDirectoryPath = Path.Combine(parentDirectory, "Sets");
                // make sure sets directory exists
                if(!Directory.Exists(setsDirectoryPath))
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

                    if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "data")
                    {
                        depth = reader.Depth + 1;
                    }

                    if (reader.TokenType == JsonToken.PropertyName && reader.Depth == depth)
                    {
                        setCode = (string)reader.Value;
                    }

                    if (reader.TokenType == JsonToken.StartObject && reader.Depth == depth)
                    {
                        MTGJsonAllPrintingsSet set = serializer.Deserialize<MTGJsonAllPrintingsSet>(reader);                        
                        File.WriteAllText(Path.Combine(setsDirectoryPath, string.Format("{0}.json", setCode)), JsonConvert.SerializeObject(set));
                    }
                }                  
            }

            return null;
        }
    }
}
