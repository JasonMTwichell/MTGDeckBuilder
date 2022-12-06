import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { CardSearchService } from '../../core/card-search.service';
import { ListActionEvent } from '../../core/events/list-action-event';
import { AddCardToListEvent } from '../../core/events/add-card-to-list-event';
import { Card } from '../../core/models/card';
import { CardList } from '../../core/models/card-list';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
import { ListSelectedEvent } from '../../core/events/list-selected-event';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.scss'],
  providers: [CardSearchService]
})
export class MainSearchComponent implements OnInit {
  searchCriteria: CardSearchCriteria;
  searchResults: Card[];
  cardLists: CardList[];
  listCards: Card[];
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
    this.listCards = [];
  }

  ngOnInit(): void {
    this.cardSearchSvc.getCardSearchCriteria().subscribe(val => this.searchCriteria = val);
    this.getCardLists();
  }

  getCardLists() {
    this.cardSearchSvc.getCardLists().subscribe(val => this.cardLists = val);
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
    this.cardSearchSvc.getCardListCards(event.cardList.cardListID).subscribe(listCards => {
      console.log(listCards);
      this.listCards = listCards;
    });
  }

  handleListEvent(event: ListActionEvent) {
    if (event.actionType == "ADD") {
      if (event.cardList.name != null) {
        this.cardSearchSvc.createCardList(event.cardList).subscribe(onDone => this.getCardLists());
      }
    } else if (event.actionType == "UPDATE") {
      if (event.cardList.name != null && event.cardList.cardListID != null) {
        this.cardSearchSvc.updateCardList(event.cardList).subscribe(onDone => this.getCardLists());
      }
    }
  }
}
