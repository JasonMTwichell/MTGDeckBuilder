namespace MTGDeckBuilder.API.ViewModels
{
    public record UpdateCardListViewModel
    {
        public int CardListID { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
