import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlecommentComponent } from './articlecomment.component';

describe('ArticlecommentComponent', () => {
  let component: ArticlecommentComponent;
  let fixture: ComponentFixture<ArticlecommentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticlecommentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlecommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
