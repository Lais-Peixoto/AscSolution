import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCampComponent } from './show-camp.component';

describe('ShowCampComponent', () => {
  let component: ShowCampComponent;
  let fixture: ComponentFixture<ShowCampComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCampComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
