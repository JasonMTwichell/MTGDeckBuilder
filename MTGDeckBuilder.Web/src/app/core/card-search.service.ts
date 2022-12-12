import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCardToList } from './models/add-card-to-list';
import { Card } from './models/card';
import { CardList } from './models/card-list';
import { CardListCard } from './models/card-list-card';
import { CardSearchCriteria } from './models/card-search-criteria';
import { CardSearchParameters } from './models/card-search-parameters';
import { DeleteCardListCards } from './models/delete-card-list-cards';
import { ListItemViewModel } from './models/list-item-viewmodel';

@Injectable({
  providedIn: 'root'
})
export class CardSearchService {
  private searchUrl: string = '/api/cardSearch';
  private cardListUrl: string = '/api/cardList';  

  constructor(private http: HttpClient) { }

  //#region Card Search
  getCardSearchCriteria(): Observable<CardSearchCriteria> {    
    return this.http.get<CardSearchCriteria>(this.searchUrl);
  }

  searchCards(params: CardSearchParameters): Observable<Card[]> {    
    return this.http.post<Card[]>(this.searchUrl, params);
  }
  //#endregion

  //#region Card List
  createCardList(cardList: CardList) {    
    return this.http.post(this.cardListUrl, cardList);
  }

  getCardLists(): Observable<CardList[]> {    
    return this.http.get<CardList[]>(this.cardListUrl);
  }

  getCardList(cardListID: number): Observable<CardList> {
    const getCardListUrl = `${this.cardListUrl}/${cardListID}`;
    return this.http.get<CardList>(getCardListUrl);    
  }

  updateCardList(cardList: CardList) {
    const putCardListUrl = `${this.cardListUrl}/${cardList.cardListID}`;
    return this.http.put(putCardListUrl, cardList);
  }

  deleteCardList(cardListID: number) {
    const deleteCardListUrl = `${this.cardListUrl}/${cardListID}`;
    return this.http.delete(deleteCardListUrl);
  }
  //#endregion 

  //#region Card List Card
  addCardToList(params: AddCardToList) {
    const addToListURL = `${this.cardListUrl}/${params.cardListID}/cardListCards`;
    return this.http.post(addToListURL, params);
  }

  getCardListCards(cardListID: number): Observable<CardListCard[]> {
    const getCardListCardsUrl = `/api/cardList/${cardListID}/cardlistcards`;
    return this.http.get<CardListCard[]>(getCardListCardsUrl);
  }

  deleteCardListCards(params: DeleteCardListCards) {
    const deleteCardListUrl = `${this.cardListUrl}/${params.cardListID}/cardListCards`;
    return this.http.delete(deleteCardListUrl, { body: params });
  }
  //#endregion
}
