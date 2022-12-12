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
import { ListSelectedEvent } from '../../core/events/list-selected-event';
import { EditListDialogComponent } from '../edit-list-dialog/edit-list-dialog.component';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-list-manager',
  templateUrl: './list-manager.component.html',
  styleUrls: ['./list-manager.component.scss']
})
export class ListManagerComponent implements OnInit {
  @Input() cardLists: CardList[];
  @Input() listCards: Card[];
  @Output() listSelectedEventEmitter: EventEmitter<ListSelectedEvent>;
  @Output() listActionEventEmitter: EventEmitter<ListActionEvent>;
  @Output() listItemActionEventEmitter: EventEmitter<ListItemActionEvent>;  
  selectedListItems: string[];
    selectedCardList: any;
  constructor(public dialog: MatDialog) {
    this.cardLists = [];
    this.listSelectedEventEmitter = new EventEmitter<ListSelectedEvent>();
    this.listActionEventEmitter = new EventEmitter<ListActionEvent>();
    this.listItemActionEventEmitter = new EventEmitter<ListItemActionEvent>();
    this.listCards = [];
    this.selectedListItems = [];
  }

  ngOnInit(): void {
  }

  onListSelected(event: any) {
    console.log(event);
    if (event.value && event.value != 0) {
      this.selectedCardList = event.value;
      this.listSelectedEventEmitter.emit({ cardListID: event.value.cardListID });
    } else {
      this.listCards = [];
    }
  }

  addList() {
    const dialogRef = this.dialog.open(EditListDialogComponent, {      
      data: {        
        name: "",
        description: "",
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result.name != null) {
        this.listActionEventEmitter.emit({
          actionType: "ADD",
          cardListID: result.cardListID,
          name: result.name,
          description: result.description,
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
      if (result.name != null && result.cardListID != null) {
        this.listActionEventEmitter.emit({
          actionType: "UPDATE",
          cardListID: result.cardListID,
          name: result.name,
          description: result.description,
        });
      }
    });
  }

  deleteList(cardListID: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {
        dialogTitle: "Delete Cards from List?",
        dialogMessage: "Click confirm to delete the selected cards from the list.",
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
      if (result == true) {
        this.listActionEventEmitter.emit({
          actionType: "DELETE",
          cardListID: cardListID,
        });

        this.selectedCardList = {};
        this.listCards = [];
      }
    });
  }

  removeFromList() {
    console.log(`Removing ${this.selectedListItems} from this list`);
    this.listItemActionEventEmitter.emit({
      actionType: "DELETE",
      cardListID: this.selectedCardList.cardListID,
      cardUUIDs: this.selectedListItems,
    });
  }
}
