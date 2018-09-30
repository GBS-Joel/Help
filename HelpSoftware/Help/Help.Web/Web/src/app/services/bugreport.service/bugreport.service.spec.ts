import { TestBed, inject } from '@angular/core/testing';

import { BugreportService } from './bugreport.service';

describe('BugreportService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BugreportService]
    });
  });

  it('should be created', inject([BugreportService], (service: BugreportService) => {
    expect(service).toBeTruthy();
  }));
});
