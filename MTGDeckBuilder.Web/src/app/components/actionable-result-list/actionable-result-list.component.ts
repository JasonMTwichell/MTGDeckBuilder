import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../../core/models/card';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-actionable-result-list',
  templateUrl: './actionable-result-list.component.html',
  styleUrls: ['./actionable-result-list.component.scss']
})
export class ActionableResultListComponent implements OnInit {
  @Input() cards: Card[];
  //cardDataSource: MatTableDataSource<Card>;
  headers: string[];
  constructor() {
    this.cards = [];
    //this.cardDataSource = new MatTableDataSource<Card>(this.cards);
    this.headers = ['name', 'manaCost', 'text'];
  }

  ngOnInit(): void {
  }
}
