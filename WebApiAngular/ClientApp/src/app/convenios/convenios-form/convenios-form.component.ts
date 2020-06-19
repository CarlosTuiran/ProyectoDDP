import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-convenios-form',
  templateUrl: './convenios-form.component.html',
  styleUrls: ['./convenios-form.component.css']
})
export class ConveniosFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      fecha: "",
      iD_Empresa: "",
      estado: ""
    });
  }

}
