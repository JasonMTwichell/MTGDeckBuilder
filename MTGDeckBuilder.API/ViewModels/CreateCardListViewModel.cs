namespace MTGDeckBuilder.API.ViewModels
{
    public record CreateCardListViewModel
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}