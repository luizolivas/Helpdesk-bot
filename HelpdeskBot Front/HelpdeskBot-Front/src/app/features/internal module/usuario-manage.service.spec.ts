import { TestBed } from '@angular/core/testing';

import { UsuarioManageService } from './usuario-manage.service';

describe('UsuarioManageService', () => {
  let service: UsuarioManageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UsuarioManageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
