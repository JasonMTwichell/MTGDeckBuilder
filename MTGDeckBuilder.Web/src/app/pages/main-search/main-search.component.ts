import { Component, OnInit } from '@angular/core';
import { CardSearchService } from '../../core/card-search.service';
import { CardSearchCriteria } from '../../core/models/card-search-criteria';
import { CardSearchParameters } from '../../core/models/card-search-parameters';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.scss'],
  providers: [CardSearchService]
})
export class MainSearchComponent implements OnInit {
  public _searchParams: CardSearchCriteria | null = null;
  constructor(private cardSearchSvc: CardSearchService) {

  }

  ngOnInit(): void {
    this.cardSearchSvc.getCardSearchParameters().subscribe(val => this._searchParams = val);
  }


  submitCardSearchParameters(params: CardSearchParameters): void {
    console.log(params);
    //this.cardSearchSvc.searchCards(params).subscribe(searchResults => console.log(searchResults));
  }

}
