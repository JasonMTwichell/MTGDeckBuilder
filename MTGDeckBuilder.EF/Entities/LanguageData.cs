namespace MTGDeckBuilder.EF.Entities
{
    public class LanguageData
    {
        public int? pkLanguage { get; set; }
        public string LanguageDescription { get; set; }

        public virtual ICollection<SetData> Sets { get; set; }
    }
}
