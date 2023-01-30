namespace MTGDeckBuilder.EF.Entities
{
    public class SupertypeData
    {
        public int? pkSupertype { get; set; }
        public string SupertypeDescription { get; set; }
        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
