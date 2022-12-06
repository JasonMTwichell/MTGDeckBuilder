import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Card } from '../../core/models/card';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { AddCardToListEvent } from '../../core/events/add-card-to-list-event';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
import { CardList } from '../../core/models/card-list';

@Component({
  selector: 'app-actionable-result-list',
  templateUrl: './actionable-result-list.component.html',
  styleUrls: ['./actionable-result-list.component.scss']
})
export class ActionableResultListComponent implements OnInit, AfterViewInit {
  @Input() set cards(cards: Card[]) {
    this._cards = cards;
    this.cardDataSource.data = cards;
  }
  get cards(): Card[]{
    return this._cards;
  } 
  private _cards: Card[];
  cardDataSource: MatTableDataSource<Card>;
  headers: string[];

  @Input() cardLists: CardList[];
  @Output() addToListEventEmitter: EventEmitter<AddCardToListEvent>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor() {
    this._cards = [];    
    this.cardDataSource = new MatTableDataSource<Card>([]);
    this.cardDataSource.sortingDataAccessor = (card, header) => {
      switch (header) {
        case 'manaCost':
          return card.convertedManaCost;
        case 'name':
          return card.name;
        case 'text':
          return card.text;
        case 'type':
          return card.type;        
        default:
          return ''
      }     
    }
    this.headers = ['name', 'manaCost', 'type', 'text', 'powerToughnessLoyalty', 'actions'];

    this.cardLists = [];  
    this.addToListEventEmitter = new EventEmitter<AddCardToListEvent>();
  }
    ngAfterViewInit(): void {
      this.cardDataSource.paginator = this.paginator;
      this.cardDataSource.sort = this.sort;
    }

  ngOnInit(): void {
  }

  addCardToList(cardUUID: string, listID: number) {
    this.addToListEventEmitter.emit({
      cardUUID: cardUUID,
      listID: listID
    });
  }
}
