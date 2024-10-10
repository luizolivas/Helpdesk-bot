import { TestBed } from '@angular/core/testing';

import { ImageChamadosService } from './image-chamados.service';

describe('ImageChamadosService', () => {
  let service: ImageChamadosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageChamadosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
