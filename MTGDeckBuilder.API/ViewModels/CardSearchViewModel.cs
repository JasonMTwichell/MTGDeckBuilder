namespace MTGDeckBuilder.API.ViewModels
{
    public class CardSearchViewModel
    {
        public string SearchTerm { get; set; }
        public int[]? Colors { get; set; }
        public bool? MatchColorsExactly { get; set; }
        public bool? MatchColorIdentity { get; set; }
        public int? FormatID { get; set; }
        public int? SetID { get; set; }
        public int? TypeID { get; set; }
        public int? SuperTypeID { get; set; }
        public int? SubTypeID { get; set; }
        public int? KeywordID { get; set; }
    }
}
