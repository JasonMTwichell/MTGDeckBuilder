import { ListItemViewModel } from "./list-item-viewmodel";

export interface CardSearchCriteria {
  colors: ListItemViewModel<number>[];
  sets: ListItemViewModel<number>[];
  formats: ListItemViewModel<number>[];
  types: ListItemViewModel<number>[];
  superTypes: ListItemViewModel<number>[];
  subTypes: ListItemViewModel<number>[];
  keywords: ListItemViewModel<number>[];
}
