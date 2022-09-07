﻿namespace MTGDeckBuilder.API.ViewModels
{
    public class SearchCriteriaViewModel
    {
        public IEnumerable<ListItemViewModel<int>> Colors { get; set; }
        public IEnumerable<ListItemViewModel<int>> Sets { get; set; }
        public IEnumerable<ListItemViewModel<int>> Formats { get; set; }
        public IEnumerable<ListItemViewModel<int>> Types { get; set; }
        public IEnumerable<ListItemViewModel<int>> SuperTypes { get; set; }
        public IEnumerable<ListItemViewModel<int>> SubTypes { get; set; }
    }
}