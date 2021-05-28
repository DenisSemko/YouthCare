import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarSportsmanComponent } from './sidebar-sportsman.component';

describe('SidebarSportsmanComponent', () => {
  let component: SidebarSportsmanComponent;
  let fixture: ComponentFixture<SidebarSportsmanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarSportsmanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarSportsmanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
