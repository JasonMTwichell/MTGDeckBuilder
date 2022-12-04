import { Component, EventEmitter, Input, OnInit, Output, QueryList, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectionListChange } from '@angular/material/list';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ListActionEvent } from '../../core/events/list-action-event';
import { ListItemActionEvent } from '../../core/events/list-item-action-event';
import { Card } from '../../core/models/card';
import { CardList } from '../../core/models/card-list';
import { ListItemViewModel } from '../../core/models/list-item-viewmodel';
import { ListSelectedEvent } from '../../core/models/list-selected-event';
import { EditListDialogComponent } from '../edit-list-dialog/edit-list-dialog.component';

@Component({
  selector: 'app-list-manager',
  templateUrl: './list-manager.component.html',
  styleUrls: ['./list-manager.component.scss']
})
export class ListManagerComponent implements OnInit {
  @Input() lists: ListItemViewModel<number>[];
  @Output() listSelectedEventEmitter: EventEmitter<ListSelectedEvent>;
  @Output() listActionEventEmitter: EventEmitter<ListActionEvent>;
  @Output() listItemActionEventEmitter: EventEmitter<ListItemActionEvent>;
  @Input() cardList: CardList;
  selectedListItems: string[];
  constructor(public dialog: MatDialog) {
    this.lists = [];
    this.listSelectedEventEmitter = new EventEmitter<ListSelectedEvent>();
    this.listActionEventEmitter = new EventEmitter<ListActionEvent>();
    this.listItemActionEventEmitter = new EventEmitter<ListItemActionEvent>();
    this.cardList = {
      cardListName: "",
      cardListDescription: "",
      cards: [],
    }
    this.selectedListItems = [];
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

  addList() {
    const dialogRef = this.dialog.open(EditListDialogComponent, {      
      data: {        
        cardListName: "",
        cardListDescription: "",
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result.cardListName != null) {
        this.listActionEventEmitter.emit({
          actionType: "ADD",
          cardList: result,
        });
      }
    });
  }

  editList(list: CardList) {
    const dialogRef = this.dialog.open(EditListDialogComponent, {
      data: list
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
      if (result.cardListName != null && result.cardListID != null) {
        this.listActionEventEmitter.emit({
          actionType: "UPDATE",
          cardList: result,
        });
      }
    });
  }

  removeFromList() {
    console.log(`Removing ${this.selectedListItems} from this list`);

  }
}
