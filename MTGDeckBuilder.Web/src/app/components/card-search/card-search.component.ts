import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
@Component({
  selector: 'app-card-search',
  templateUrl: './card-search.component.html',
  styleUrls: ['./card-search.component.scss']
})
export class CardSearchComponent implements OnInit {
  @Input() searchCriteria: CardSearchCriteria|null = null;
  @Output() submitEvent: EventEmitter<CardSearchParameters>;
  cardSearchForm: FormGroup;
  constructor(private _formBuilder: FormBuilder) {
    this.submitEvent = new EventEmitter<CardSearchParameters>();    

    this.cardSearchForm = new FormGroup({
      searchTerm: new FormControl(''),
      searchNameText: new FormControl(false),
      searchTypesText: new FormControl(false),
      searchRulesText: new FormControl(false),
      searchWhite: new FormControl(false),
      searchBlue: new FormControl(false),
      searchRed: new FormControl(false),
      searchBlack: new FormControl(false),
      searchGreen: new FormControl(false),
      matchColorsExactly: new FormControl(false),
      excludeUnselectedColors: new FormControl(false),
      matchMulticolorOnly: new FormControl(false),
      matchColorIdentity: new FormControl(false),
      formatFilter: new FormControl(null),
      setFilter: new FormControl(null),
      typeFilter: new FormControl(null),
      subTypeFilter: new FormControl(null),
      keywordFilter: new FormControl(null),
    }); 
  }

  ngOnInit(): void {
    
  }

  submit() {
    console.log(this.cardSearchForm.value);

    // TODO: just make sure that theres at least one value
    let searchFormValue = this.cardSearchForm.value;
    this.submitEvent.emit({
      searchTerm: searchFormValue.searchTerm,
      searchNameText: searchFormValue.searchNameText,
      searchTypesText: searchFormValue.searchTypesText,
      searchRulesText: searchFormValue.searchRulesText,
      searchWhite: searchFormValue.searchWhite,
      searchBlue: searchFormValue.searchBlue,
      searchRed: searchFormValue.searchRed,
      searchBlack: searchFormValue.searchBlack,
      searchGreen: searchFormValue.searchGreen,
      matchColorsExactly: searchFormValue.matchColorsExactly,
      excludeUnselectedColors: searchFormValue.excludeUnselectedColors,
      matchMulticolorOnly: searchFormValue.matchMulticolorOnly,
      matchColorIdentity: searchFormValue.matchColorIdentity,
      formatID: searchFormValue.formatFilter,
      setID: searchFormValue.setFilter,
      typeID: searchFormValue.typeFilter,
      subTypeID: searchFormValue.subTypeFilter,
      keywordID: searchFormValue.keywordFilter,
    });
  }
}
