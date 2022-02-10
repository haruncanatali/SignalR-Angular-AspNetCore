import { TestBed } from '@angular/core/testing';

import { TanimService } from './tanim.service';

describe('TanimService', () => {
  let service: TanimService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TanimService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
