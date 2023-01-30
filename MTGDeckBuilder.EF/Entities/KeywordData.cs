namespace MTGDeckBuilder.EF.Entities
{
    public class KeywordData
    {
        public int? pkKeyword { get; set; }
        public int? fkKeywordType { get; set; }
        public string KeywordDescription { get; set; }

        public virtual KeywordTypeData? KeywordType { get; set; }
        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
