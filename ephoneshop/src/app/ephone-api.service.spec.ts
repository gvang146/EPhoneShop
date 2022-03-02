import { TestBed } from '@angular/core/testing';

import { EphoneAPIService } from './ephone-api.service';

describe('EphoneAPIService', () => {
  let service: EphoneAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EphoneAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
