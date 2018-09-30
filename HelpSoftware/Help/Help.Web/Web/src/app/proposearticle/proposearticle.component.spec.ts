import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProposearticleComponent } from './proposearticle.component';

describe('ProposearticleComponent', () => {
  let component: ProposearticleComponent;
  let fixture: ComponentFixture<ProposearticleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProposearticleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProposearticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
