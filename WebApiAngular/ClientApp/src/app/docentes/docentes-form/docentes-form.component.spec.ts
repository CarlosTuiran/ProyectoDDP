import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocentesFormComponent } from './docentes-form.component';

describe('DocentesFormComponent', () => {
  let component: DocentesFormComponent;
  let fixture: ComponentFixture<DocentesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocentesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocentesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
