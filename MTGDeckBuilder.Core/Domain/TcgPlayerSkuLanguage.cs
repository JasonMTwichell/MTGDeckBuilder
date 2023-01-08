namespace MTGDeckBuilder.Core.Domain
{
    public record TcgPlayerSkuLanguage
    {
        public int? TcgPlayerSkuLanguageID { get; init; }
        public string LanguageDescription { get; init; }
    }
}
