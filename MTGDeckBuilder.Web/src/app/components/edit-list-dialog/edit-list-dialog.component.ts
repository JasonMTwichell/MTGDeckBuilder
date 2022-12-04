import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog'
import { CardList } from '../../core/models/card-list';

@Component({
  selector: 'app-edit-list-dialog',
  templateUrl: './edit-list-dialog.component.html',
  styleUrls: ['./edit-list-dialog.component.scss']
})
export class EditListDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<EditListDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CardList) { }

  ngOnInit(): void {
  }

  onClose() {
    console.log("On no close firing");
    this.dialogRef.close();
  }
}
