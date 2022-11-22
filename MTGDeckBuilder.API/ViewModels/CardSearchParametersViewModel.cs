using System.ComponentModel.DataAnnotations;

namespace MTGDeckBuilder.API.ViewModels
{
    public class CardSearchParametersViewModel: IValidatableObject
    {
        public string?  SearchTerm { get; set; }
        public int[]? SearchColors { get; set; }
        public bool? SearchNameText { get; set; }        
        public bool? SearchRulesText { get; set; }        
        public bool? MatchColorsExactly { get; set; }
        public bool? MatchMulticolorOnly { get; set; }
        public bool? MatchColorIdentity { get; set; }
        public bool? ExcludeUnselectedColors { get; set; }
        public int? FormatID { get; set; }
        public int? SetID { get; set; }
        public int? TypeID { get; set; }
        public int? SuperTypeID { get; set; }
        public int? SubTypeID { get; set; }
        public int? KeywordID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(((SearchRulesText == null || SearchRulesText == false) && (SearchNameText == null || SearchNameText == false)) && !string.IsNullOrEmpty(SearchTerm))
            {
                yield return new ValidationResult("Must search either name or rules text if a search term is specified.");
            }
        }
    }
}
