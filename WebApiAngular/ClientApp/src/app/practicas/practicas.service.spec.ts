import { TestBed } from '@angular/core/testing';

import { PracticasService } from './practicas.service';

describe('PracticasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PracticasService = TestBed.get(PracticasService);
    expect(service).toBeTruthy();
  });
});
