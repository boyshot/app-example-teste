import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPersonPhoneComponent } from './list-person-phone.component';

describe('ListPersonPhoneComponent', () => {
  let component: ListPersonPhoneComponent;
  let fixture: ComponentFixture<ListPersonPhoneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPersonPhoneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPersonPhoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
