import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderSportsmanComponent } from './header-sportsman.component';

describe('HeaderSportsmanComponent', () => {
  let component: HeaderSportsmanComponent;
  let fixture: ComponentFixture<HeaderSportsmanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderSportsmanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderSportsmanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
