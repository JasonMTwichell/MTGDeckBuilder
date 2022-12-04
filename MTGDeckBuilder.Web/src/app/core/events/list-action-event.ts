import { CardList } from "../models/card-list";

export interface ListActionEvent {
  actionType: string;
  cardList: CardList;
}
