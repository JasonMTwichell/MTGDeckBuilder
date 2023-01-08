namespace MTGDeckBuilder.Core.Domain
{
    public record Language
    {
        public int? LanguageID { get; init; }
        public string LanguageDescription { get; init; }
    }
}
