import { TestBed } from '@angular/core/testing';

import { DetailPanelService } from './detail-panel.service';

describe('DetailPanelService', () => {
  let service: DetailPanelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DetailPanelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
