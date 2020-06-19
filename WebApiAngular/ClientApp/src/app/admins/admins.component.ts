import { Component, OnInit } from '@angular/core';
import { AdminsService } from './admins.service';

@Component({
  selector: 'app-admins',
  templateUrl: './admins.component.html',
  styleUrls: ['./admins.component.css']
})
export class AdminsComponent implements OnInit {

  admins: IAdmin[];
  constructor(private adminsService: AdminsService) { }

  ngOnInit() {
    this.adminsService.getAdmins()
      .subscribe(admins => this.admins = admins,
        error => console.error(error));
  }
  
}
export interface IAdmin {
  cedula: number;  
  email: string;
  nombres: string;
  apellidos: string;
}
