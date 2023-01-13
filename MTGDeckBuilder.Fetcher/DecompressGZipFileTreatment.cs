using MTGDeckBuilder.Core.Service;
using System.IO.Compression;

public class DecompressGZipFileTreatment : IFileTreatment
{
    public async Task TreatFile(string filePath, string? outputFilePath)
    {
        using (Stream reader = File.OpenRead(filePath))
        using (var decompressor = new GZipStream(reader, CompressionMode.Decompress))
        {
            if(outputFilePath == null)
            {
                string parentDirectory = Path.GetDirectoryName(filePath);
                string unzippedFileName = Path.GetFileNameWithoutExtension(filePath);
                outputFilePath = Path.Combine(parentDirectory, unzippedFileName);
            }
            
            using (FileStream fileStream = File.Create(outputFilePath))
            {
                await decompressor.CopyToAsync(fileStream);
            }
        }
    }
}


