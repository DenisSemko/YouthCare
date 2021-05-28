import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportsmanProfileComponent } from './sportsman-profile.component';

describe('SportsmanProfileComponent', () => {
  let component: SportsmanProfileComponent;
  let fixture: ComponentFixture<SportsmanProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SportsmanProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SportsmanProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
