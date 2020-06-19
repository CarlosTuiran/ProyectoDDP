import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-admins-form',
  templateUrl: './admins-form.component.html',
  styleUrls: ['./admins-form.component.css']
})
export class AdminsFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      cedula: "",
      email: "",
      nombres:"", 
      apellidos:""

    });
  }

}
