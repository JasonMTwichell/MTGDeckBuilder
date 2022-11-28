import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCardToList } from './models/add-card-to-list';
import { Card } from './models/card';
import { CardSearchCriteria } from './models/card-search-criteria';
import { CardSearchParameters } from './models/card-search-parameters';
import { ListItemViewModel } from './models/list-item-viewmodel';

@Injectable({
  providedIn: 'root'
})
export class CardSearchService {

  constructor(private _http: HttpClient) { }

  getCardSearchParameters(): Observable<CardSearchCriteria> {
    const cardSearchParametersUrl: string = '/mtgsearch/GetSearchCriteria';
    return this._http.get<CardSearchCriteria>(cardSearchParametersUrl);
  }

  searchCards(params: CardSearchParameters): Observable<Card[]> {
    const cardSearchParametersUrl: string = '/mtgsearch/Search';
    return this._http.post<Card[]>(cardSearchParametersUrl, params);
  }

  getCardListReferences(): Observable<ListItemViewModel<number>[]> {
    const cardListsUrl: string = '/deckbuilder/GetListReferences';
    return this._http.get<ListItemViewModel<number>[]>(cardListsUrl);
  }

  addCardToList(params: AddCardToList) {
    const addToListURL: string = '/deckbuilder/addCardToList';
    return this._http.post(addToListURL, params);
  }
}
