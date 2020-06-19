import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-estudiantes-form',
  templateUrl: './estudiantes-form.component.html',
  styleUrls: ['./estudiantes-form.component.css']
})
export class EstudiantesFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      email: "",
      nombres: "",
      apellidos: "",
      docIdentidad: "",
      carrera: "",
      celular: "",
      direccion: "",
      departamento: "",
      ciudad: "",
      telefono: ""
    });
  }

}
