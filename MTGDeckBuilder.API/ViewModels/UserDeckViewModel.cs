namespace MTGDeckBuilder.API.ViewModels
{
    public record UserDeckViewModel
    {
        public int UserDeckID { get; init; }
        public string UserDeckName { get; init; }
        public string? UserDeckDescription { get; init; }
    }
}
