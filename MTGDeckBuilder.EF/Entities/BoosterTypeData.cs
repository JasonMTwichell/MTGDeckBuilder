﻿namespace MTGDeckBuilder.EF.Entities
{
    public class BoosterTypeData
    {
        public int? pkBoosterType { get; set; }
        public string BoosterTypeDescription { get; set; }
        public virtual ICollection<SetCardData>? SetCards { get; set; }
    }
}
