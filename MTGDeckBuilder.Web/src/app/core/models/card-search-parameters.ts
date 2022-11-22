export interface CardSearchParameters {
  searchTerm?: string;
  searchNameText?: boolean;
  searchTypesText?: boolean;
  searchRulesText?: boolean;
  searchWhite?: boolean;
  searchBlue?: boolean;
  searchRed?: boolean;
  searchBlack?: boolean;
  searchGreen?: boolean;  
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
