namespace MTGDeckBuilder.API.ViewModels
{
    public class CardListViewModel
    {
        public int? CardListID { get; set; }
        public string CardListName { get; set; }
        public string? CardListDescription { get; set; }
        public IEnumerable<CardViewModel>? Cards { get; set; }
    }
}
