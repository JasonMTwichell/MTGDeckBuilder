using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardListData
    {
        public int pkCardList { get; set; }
        public string CardListName { get; set; }
        public string? CardListDescription { get; set; } 

        public virtual ICollection<CardListCardData> ListCards { get; set; }        
    }
}
