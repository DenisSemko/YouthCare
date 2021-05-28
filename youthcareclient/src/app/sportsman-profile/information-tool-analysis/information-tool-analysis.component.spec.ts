import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationToolAnalysisComponent } from './information-tool-analysis.component';

describe('InformationToolAnalysisComponent', () => {
  let component: InformationToolAnalysisComponent;
  let fixture: ComponentFixture<InformationToolAnalysisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InformationToolAnalysisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InformationToolAnalysisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
