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
import { ListItemActionEvent } from '../../core/events/list-item-action-event';

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
  selectedCardListID?: number;
  cardListCards: Card[];
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
    this.cardListCards = [];
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
    this.cardSearchSvc.addCardToList({ cardUUID: event.cardUUID, cardListID: event.listID }).subscribe(_ => {
      if (event.listID == this.selectedCardListID) {
        this.getListCards({ cardListID: event.listID });
      }
    });
  }

  getListCards(event: ListSelectedEvent) {
    console.log(event);
    this.cardSearchSvc.getCardListCards(event.cardListID).subscribe(listCards => {
      console.log(listCards);
      this.selectedCardListID = event.cardListID;
      this.cardListCards = listCards;
    });
  }

  handleListEvent(event: ListActionEvent) {
    if (event.actionType == "ADD") {
      if (event.name != null) {
        const cardList: CardList = {
          cardListID: event.cardListID,
          name: event.name,
          description: event.description,
        };

        this.cardSearchSvc.createCardList(cardList).subscribe(_ => this.getCardLists());
      }
    } else if (event.actionType == "UPDATE") {
      if (event.name != null && event.cardListID != null) {
        const cardList: CardList = {
          cardListID: event.cardListID,
          name: event.name,
          description: event.description,
        };

        this.cardSearchSvc.updateCardList(cardList).subscribe(_ => this.getCardLists());
      }
    } else if (event.actionType == "DELETE") {
      if (event.cardListID != null) {
        this.cardSearchSvc.deleteCardList(event.cardListID).subscribe(_ => {          
          this.getCardLists();
        });
      }
    }
  }

  handleListItemEvent(event: ListItemActionEvent) {
    if (event.actionType == "DELETE" && event.cardUUIDs.length > 0) {
      this.cardSearchSvc.deleteCardListCards({
        cardListID: event.cardListID,
        cardUUIDsToDelete: event.cardUUIDs,
      }).subscribe(_ => this.getListCards({ cardListID: event.cardListID }));
    }
  }
}
