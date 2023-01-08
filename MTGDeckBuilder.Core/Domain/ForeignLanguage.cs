namespace MTGDeckBuilder.Core.Domain
{
    public record ForeignLanguage
    {
        public int? ForeignLanguageID { get; init; }
        public string ForeignLanguageDescription { get; init; }
    }
}
