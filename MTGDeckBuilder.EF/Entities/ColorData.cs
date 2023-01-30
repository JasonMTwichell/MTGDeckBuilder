namespace MTGDeckBuilder.EF.Entities
{
    public class ColorData
    {
        public int? pkColor { get; set; }
        public string ColorDescription { get; set; }
        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
