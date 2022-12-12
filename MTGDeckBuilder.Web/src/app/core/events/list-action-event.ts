import { CardList } from "../models/card-list";

export interface ListActionEvent {
  actionType: string;
  cardListID: number;
  name?: string;
  description?: string;
}
