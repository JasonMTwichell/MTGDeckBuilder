import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { throwError } from 'rxjs';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
@Component({
  selector: 'app-card-search',
  templateUrl: './card-search.component.html',
  styleUrls: ['./card-search.component.scss']
})
export class CardSearchComponent implements OnInit {
  @Input() searchCriteria: CardSearchCriteria;
  @Output() submitEvent: EventEmitter<CardSearchParameters>;
  cardSearchForm: FormGroup;
  constructor(private _formBuilder: FormBuilder) {
    this.searchCriteria = {
      colors: [],
      sets: [],
      formats: [],
      types: [],
      superTypes: [],
      subTypes: [],
      keywords: [],
    };

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
    let searchFormValue = this.cardSearchForm.value;

    let selectedColorFilters: number[] = [];
    if (searchFormValue.searchWhite) {
      selectedColorFilters.push(this.getColor('W'));
    }
    if (searchFormValue.searchBlue) {
      selectedColorFilters.push(this.getColor('U'));
    }
    if (searchFormValue.searchRed) {
      selectedColorFilters.push(this.getColor('R'));
    }
    if (searchFormValue.searchBlack) {
      selectedColorFilters.push(this.getColor('B'));
    }
    if (searchFormValue.searchGreen) {
      selectedColorFilters.push(this.getColor('G'));
    }    

    // TODO: make sure we have at least one text to search if we have a keyword
    this.submitEvent.emit({
      searchTerm: searchFormValue.searchTerm,
      searchNameText: searchFormValue.searchNameText,      
      searchRulesText: searchFormValue.searchRulesText,
      searchColors: selectedColorFilters,
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

  getColor(colorName: string): number {
    let colorValue = this.searchCriteria?.colors.find(c => c.name == colorName)?.value;
    if (colorValue == null) {
      throw new Error("Color not found in colors array.");
    } else {
      return colorValue;
    }
  }
}
