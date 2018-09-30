import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PushuserComponent } from './pushuser.component';

describe('PushuserComponent', () => {
  let component: PushuserComponent;
  let fixture: ComponentFixture<PushuserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PushuserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PushuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
