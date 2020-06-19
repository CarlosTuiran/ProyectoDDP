import { Component, OnInit } from '@angular/core';
import { EmpresasService } from './empresas.service';

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})
export class EmpresasComponent implements OnInit {

  empresas: IEmpresa[];
  

  constructor(private empresasService: EmpresasService) { }

  ngOnInit() {
    this.empresasService.getEmpresas()
      .subscribe(empresas => this.empresas = empresas,
        error => console.error(error));
  }

}
export interface IEmpresa {

  nit: number;
  email: string;
  nombresRepresentante:string;
  apellidosRepresentante:string;
  estado: string;
}
