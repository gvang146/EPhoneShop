import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCheckoutComponent } from './show-checkout.component';

describe('ShowCheckoutComponent', () => {
  let component: ShowCheckoutComponent;
  let fixture: ComponentFixture<ShowCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCheckoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
