import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultSportsmanComponent } from './default-sportsman.component';

describe('DefaultSportsmanComponent', () => {
  let component: DefaultSportsmanComponent;
  let fixture: ComponentFixture<DefaultSportsmanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultSportsmanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultSportsmanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
