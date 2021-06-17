import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompeonatoComponent } from './compeonato.component';

describe('CompeonatoComponent', () => {
  let component: CompeonatoComponent;
  let fixture: ComponentFixture<CompeonatoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompeonatoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompeonatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
