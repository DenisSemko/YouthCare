import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportsmanChatComponent } from './sportsman-chat.component';

describe('SportsmanChatComponent', () => {
  let component: SportsmanChatComponent;
  let fixture: ComponentFixture<SportsmanChatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SportsmanChatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SportsmanChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
