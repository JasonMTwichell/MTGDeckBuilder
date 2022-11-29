import { Card } from "./card";

export interface CardList {
  cardListID?: number;
  cardListName: string;
  cardListDescription: string;
  cards: Card[];
}
