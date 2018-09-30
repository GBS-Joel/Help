import { TestBed, inject } from '@angular/core/testing';

import { ArticleFeedService } from './article-feed.service';

describe('ArticleFeedService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ArticleFeedService]
    });
  });

  it('should be created', inject([ArticleFeedService], (service: ArticleFeedService) => {
    expect(service).toBeTruthy();
  }));
});
