import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCusComponent } from './add-edit-cus.component';

describe('AddEditCusComponent', () => {
  let component: AddEditCusComponent;
  let fixture: ComponentFixture<AddEditCusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditCusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditCusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
