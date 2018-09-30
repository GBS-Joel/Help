import { TestBed, inject } from '@angular/core/testing';

import { ProfilecommentService } from './profilecomment.service';

describe('ProfilecommentService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfilecommentService]
    });
  });

  it('should be created', inject([ProfilecommentService], (service: ProfilecommentService) => {
    expect(service).toBeTruthy();
  }));
});
