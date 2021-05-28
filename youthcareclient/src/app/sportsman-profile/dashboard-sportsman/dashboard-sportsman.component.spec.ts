import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardSportsmanComponent } from './dashboard-sportsman.component';

describe('DashboardSportsmanComponent', () => {
  let component: DashboardSportsmanComponent;
  let fixture: ComponentFixture<DashboardSportsmanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardSportsmanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardSportsmanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
