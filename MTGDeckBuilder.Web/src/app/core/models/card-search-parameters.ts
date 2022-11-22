export interface CardSearchParameters {
  searchTerm?: string;
  searchNameText?: boolean;  
  searchRulesText?: boolean;
  searchColors?: number[];
  matchColorsExactly?: boolean;
  excludeUnselectedColors?: boolean;
  matchMulticolorOnly?: boolean;
  matchColorIdentity?: boolean;
  formatID?: number;
  setID?: number;
  typeID?: number;
  superTypeID?: number;
  subTypeID?: number;
  keywordID?: number;
}
