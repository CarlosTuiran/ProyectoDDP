import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-practicas-form',
  templateUrl: './practicas-form.component.html',
  styleUrls: ['./practicas-form.component.css']
})
export class PracticasFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      idEstudiante: "",
      idDocente: "",
      idEmpresa: "",
      descripcion: "",
      estado: "",
      primerCorte: "",
      segundoCorte: "",
      tercerCorte: "",
      definitiva: ""
    });
  }

}
