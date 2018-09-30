import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileotherComponent } from './profileother.component';

describe('ProfileotherComponent', () => {
  let component: ProfileotherComponent;
  let fixture: ComponentFixture<ProfileotherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileotherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileotherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
