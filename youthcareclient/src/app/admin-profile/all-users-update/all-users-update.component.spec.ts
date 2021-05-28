import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllUsersUpdateComponent } from './all-users-update.component';

describe('AllUsersUpdateComponent', () => {
  let component: AllUsersUpdateComponent;
  let fixture: ComponentFixture<AllUsersUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllUsersUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllUsersUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
