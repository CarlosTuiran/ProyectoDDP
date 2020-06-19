import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-empresas-form',
  templateUrl: './empresas-form.component.html',
  styleUrls: ['./empresas-form.component.css']
})
export class EmpresasFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      nit: "",
      email: "",
      nombresRepresentante: "",
      apellidosRepresentante: "",
      estado: ""
    });
  }

}
