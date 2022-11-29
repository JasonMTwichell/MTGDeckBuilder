import { Component, OnInit } from '@angular/core';
import { CardSearchService } from '../../core/card-search.service';
import { AddCardToListEvent } from '../../core/models/add-card-to-list-event';
import { Card } from '../../core/models/card';
import { CardList } from '../../core/models/card-list';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
import { ListSelectedEvent } from '../../core/models/list-selected-event';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.scss'],
  providers: [CardSearchService]
})
export class MainSearchComponent implements OnInit {
  searchCriteria: CardSearchCriteria;
  searchResults: Card[];
  cardLists: ListItemViewModel<number>[];
  cardList: CardList;
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

    this.cardLists = [];
    this.cardList = {
      cardListName: "",
      cardListDescription: "",
      cards: [],
    };
  }

  ngOnInit(): void {
    this.cardSearchSvc.getCardSearchParameters().subscribe(val => this.searchCriteria = val);
    this.cardSearchSvc.getCardListReferences().subscribe(val => this.cardLists = val);
  }

  submitCardSearchParameters(params: CardSearchParameters): void {
    console.log(params);
    this.cardSearchSvc.searchCards(params).subscribe(searchResults => {
      console.log(searchResults);
      this.searchResults = searchResults;
    });
  }

  addCardToList(event: AddCardToListEvent) {
    console.log(event);
    this.cardSearchSvc.addCardToList({ cardUUID: event.cardUUID, cardListID: event.listID }).subscribe(e => console.log("Added card to list."));
  }

  getListCards(event: ListSelectedEvent) {
    console.log(event);
    this.cardSearchSvc.getCardList(event.listID).subscribe(val => this.cardList = val);
  }

}
