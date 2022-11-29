import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Card } from '../../core/models/card';
import { CardList } from '../../core/models/card-list';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
import { ListSelectedEvent } from '../../core/models/list-selected-event';

@Component({
  selector: 'app-list-manager',
  templateUrl: './list-manager.component.html',
  styleUrls: ['./list-manager.component.scss']
})
export class ListManagerComponent implements OnInit {
  @Input() lists: ListItemViewModel<number>[];
  @Output() listSelectedEventEmitter: EventEmitter<ListSelectedEvent>;
  @Input() cardList: CardList;

  constructor() {
    this.lists = [];
    this.listSelectedEventEmitter = new EventEmitter<ListSelectedEvent>();
    this.cardList = {
      cardListName: "",
      cardListDescription: "",
      cards: [],
    }
  }

  ngOnInit(): void {
  }

  emitListSelectionChange(event: any) {
    console.log(event);
    if (event.value && event.value != 0) {
      this.listSelectedEventEmitter.emit({ listID: event.value });
    } else {
      this.cardList = {
        cardListName: "",
        cardListDescription: "",
        cards: [],
      };
    }
  }
}
