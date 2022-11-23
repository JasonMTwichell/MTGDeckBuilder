import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Card } from './models/card';
import { CardSearchCriteria } from './models/card-search-criteria';
import { CardSearchParameters } from './models/card-search-parameters';

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
}



