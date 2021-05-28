import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationToolSportsmenlistComponent } from './information-tool-sportsmenlist.component';

describe('InformationToolSportsmenlistComponent', () => {
  let component: InformationToolSportsmenlistComponent;
  let fixture: ComponentFixture<InformationToolSportsmenlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InformationToolSportsmenlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InformationToolSportsmenlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
