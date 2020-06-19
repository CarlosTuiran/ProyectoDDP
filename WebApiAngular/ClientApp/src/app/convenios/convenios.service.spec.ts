import { TestBed } from '@angular/core/testing';

import { ConveniosService } from './convenios.service';

describe('ConveniosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ConveniosService = TestBed.get(ConveniosService);
    expect(service).toBeTruthy();
  });
});
