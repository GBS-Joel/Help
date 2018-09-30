import { TestBed, inject } from '@angular/core/testing';

import { SearchhistoryService } from './searchhistory.service';

describe('SearchhistoryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SearchhistoryService]
    });
  });

  it('should be created', inject([SearchhistoryService], (service: SearchhistoryService) => {
    expect(service).toBeTruthy();
  }));
});
