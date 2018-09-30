import { TestBed, inject } from '@angular/core/testing';

import { ProposearticleService } from './proposearticle.service';

describe('ProposearticleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProposearticleService]
    });
  });

  it('should be created', inject([ProposearticleService], (service: ProposearticleService) => {
    expect(service).toBeTruthy();
  }));
});
