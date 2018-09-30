import { TestBed, inject } from '@angular/core/testing';

import { PushuserService } from './pushuser.service';

describe('PushuserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PushuserService]
    });
  });

  it('should be created', inject([PushuserService], (service: PushuserService) => {
    expect(service).toBeTruthy();
  }));
});
