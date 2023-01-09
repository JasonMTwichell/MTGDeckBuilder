namespace MTGDeckBuilder.Core.Domain
{
    public record ForeignDataLanguage
    {
        public int? ForeignLanguageID { get; init; }
        public string ForeignDataLanguageDescription { get; init; }
    }
}
