public interface IMTGJsonHttpService
{
    Task GetMetaFile(string writeToPath);
    Task GetEnumValuesFile(string writeToPath);
    Task GetAllPrintingsFile(string writeToPath);
}

