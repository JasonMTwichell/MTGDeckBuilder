import { Component, OnInit } from '@angular/core';
import { CardSearchService } from '../../core/card-search.service';
import { Card } from '../../core/models/card';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.scss'],
  providers: [CardSearchService]
})
export class MainSearchComponent implements OnInit {
  searchCriteria: CardSearchCriteria;
  searchResults: Card[];
  constructor(private cardSearchSvc: CardSearchService) {
    this.searchCriteria = {
      colors: [],
      sets: [],
      formats: [],
      types: [],
      superTypes: [],
      subTypes: [],
      keywords: [],
    };

    this.searchResults = [];
  }

  ngOnInit(): void {
    this.cardSearchSvc.getCardSearchParameters().subscribe(val => this.searchCriteria = val);
  }


  submitCardSearchParameters(params: CardSearchParameters): void {
    console.log(params);
    this.cardSearchSvc.searchCards(params).subscribe(searchResults => {
      console.log(searchResults);
      this.searchResults = searchResults;
    });
  }

}
