namespace MTGDeckBuilder.EF.Entities
{
    public class FinishData
    {
        public int? pkFinish { get; set; }
        public string FinishDescription { get; set; }
        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
