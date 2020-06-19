import { Component, OnInit } from '@angular/core';
import { DocentesService } from './docentes.service';

@Component({
  selector: 'app-docentes',
  templateUrl: './docentes.component.html',
  styleUrls: ['./docentes.component.css']
})
export class DocentesComponent implements OnInit {

  docentes: IDocente[];
  
  constructor(private docentesService: DocentesService) { }

  ngOnInit() {
    this.docentesService.getDocentes()
      .subscribe(docentes => this.docentes = docentes,
        error => console.error(error));
  }

}
export interface IDocente {
  cedula: number;
  nombre: string;
  apellido: string;
  email: string;
  estado: string;
}
