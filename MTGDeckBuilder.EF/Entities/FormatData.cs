namespace MTGDeckBuilder.EF.Entities
{
    public class FormatData
    {
        public int pkFormat { get; set; } // pk
        public string Format { get; set; } // unique index
        
        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardFormatData> CardFormats { get; set; }        
    }
}