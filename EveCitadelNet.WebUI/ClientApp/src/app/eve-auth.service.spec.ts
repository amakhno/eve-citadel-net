import { TestBed } from '@angular/core/testing';

import { EveAuthService } from './eve-auth.service';

describe('EveAuthService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EveAuthService = TestBed.get(EveAuthService);
    expect(service).toBeTruthy();
  });
});
