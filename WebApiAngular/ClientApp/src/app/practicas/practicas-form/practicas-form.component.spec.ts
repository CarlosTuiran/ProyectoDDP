import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticasFormComponent } from './practicas-form.component';

describe('PracticasFormComponent', () => {
  let component: PracticasFormComponent;
  let fixture: ComponentFixture<PracticasFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PracticasFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticasFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
