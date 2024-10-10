import { TestBed } from '@angular/core/testing';

import { StatusReportsService } from './status-chamados.service';

describe('StatusReportsService', () => {
  let service: StatusReportsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatusReportsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
