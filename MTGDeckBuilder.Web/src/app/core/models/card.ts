export interface Card {
  cardID: number;
  cardUUID: string;
  manaCost: string;
  convertedManaCost: number;
  name: string;
  text: string;
  type: string;
  power: string;
  toughness: string;
  loyalty: number;
}
