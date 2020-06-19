import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-docentes-form',
  templateUrl: './docentes-form.component.html',
  styleUrls: ['./docentes-form.component.css']
})
export class DocentesFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      cedula: "",
      nombre: "",
      apellido: "",
      email: "",
      estado: ""
    });
  }

}
