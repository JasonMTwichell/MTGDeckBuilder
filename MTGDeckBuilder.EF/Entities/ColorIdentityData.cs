namespace MTGDeckBuilder.EF.Entities
{
    public class ColorIdentityData
    {
        public int? pkColorIdentity { get; set; }
        public string ColorIdentityDescription { get; set; }

        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
