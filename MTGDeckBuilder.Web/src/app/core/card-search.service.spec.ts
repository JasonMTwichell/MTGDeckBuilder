import { TestBed } from '@angular/core/testing';

import { CardSearchService } from './card-search.service';

describe('CardSearchServiceService', () => {
  let service: CardSearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardSearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
