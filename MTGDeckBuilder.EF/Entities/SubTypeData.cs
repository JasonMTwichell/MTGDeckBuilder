namespace MTGDeckBuilder.EF.Entities
{
    public class SubtypeData
    {
        public int? pkSubtype { get; set; }
        public string SubtypeDescription { get; set; }

        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
