import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';
@Component({
  selector: 'app-card-search',
  templateUrl: './card-search.component.html',
  styleUrls: ['./card-search.component.scss']
})
export class CardSearchComponent implements OnInit {
  @Input() searchParams: CardSearchCriteria|null = null;
  @Output() submitEvent: EventEmitter<CardSearchParameters>;

  constructor() {
    this.submitEvent = new EventEmitter<CardSearchParameters>();
  }

  ngOnInit(): void {
    
  }

  submit() {
    console.log("submitting");
    this.submitEvent.emit({
      searchTerm: 'Warp',          
    })
  }
}
