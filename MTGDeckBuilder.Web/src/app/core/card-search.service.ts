import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCardToList } from './models/add-card-to-list';
import { Card } from './models/card';
import { CardList } from './models/card-list';
import { CardSearchCriteria } from './models/card-search-criteria';
import { CardSearchParameters } from './models/card-search-parameters';
import { ListItemViewModel } from './models/list-item-viewmodel';

@Injectable({
  providedIn: 'root'
})
export class CardSearchService {

  constructor(private _http: HttpClient) { }

  getCardSearchParameters(): Observable<CardSearchCriteria> {
    const cardSearchParametersUrl = '/mtgsearch/GetSearchCriteria';
    return this._http.get<CardSearchCriteria>(cardSearchParametersUrl);
  }

  searchCards(params: CardSearchParameters): Observable<Card[]> {
    const cardSearchParametersUrl = '/mtgsearch/Search';
    return this._http.post<Card[]>(cardSearchParametersUrl, params);
  }

  getCardListReferences(): Observable<ListItemViewModel<number>[]> {
    const cardListsUrl = '/deckbuilder/GetListReferences';
    return this._http.get<ListItemViewModel<number>[]>(cardListsUrl);
  }

  addCardToList(params: AddCardToList) {
    const addToListURL = '/deckbuilder/addCardToList';
    return this._http.post(addToListURL, params);
  }

  getCardList(listID: number): Observable<CardList> {
    const getListURL = '/deckbuilder/getList';    
    let params = new HttpParams().append("cardListID", listID);    
    return this._http.get<CardList>(getListURL, {params: params});
  }
}
