namespace MTGDeckBuilder.API.ViewModels
{
    public record CreateUserDeckViewModel
    {
        public string UserDeckName { get; init; }
        public string? UserDeckDescription { get; init; }
    }
}
