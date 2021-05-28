import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundedChartMainComponent } from './rounded-chart-main.component';

describe('RoundedChartMainComponent', () => {
  let component: RoundedChartMainComponent;
  let fixture: ComponentFixture<RoundedChartMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoundedChartMainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoundedChartMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
