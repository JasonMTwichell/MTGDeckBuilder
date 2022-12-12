namespace MTGDeckBuilder.API.ViewModels
{
    public record DeleteCardListCardsViewModel
    {
        public int CardListID { get; init; }
        public string[] CardUUIDsToDelete { get; init; }
    }
}
