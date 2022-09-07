namespace MTGDeckBuilder.API.ViewModels
{
    public class ListItemViewModel<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }
}
