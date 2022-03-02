import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCusComponent } from './show-cus.component';

describe('ShowCusComponent', () => {
  let component: ShowCusComponent;
  let fixture: ComponentFixture<ShowCusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
