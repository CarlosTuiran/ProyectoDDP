import { Component, OnInit } from '@angular/core';
import { PracticasService } from './practicas.service';

@Component({
  selector: 'app-practicas',
  templateUrl: './practicas.component.html',
  styleUrls: ['./practicas.component.css']
})
export class PracticasComponent implements OnInit {

  practicas: IPractica[];
  constructor(private practicasService: PracticasService) { }

  ngOnInit() {
    this.practicasService.getPracticas()
      .subscribe(practicas => this.practicas = practicas,
        error => console.error(error));
  }

}
export interface IPractica {
  idEstudiante: number; 
  idDocente: number;
  idEmpresa: number;
  descripcion: string; 
  estado: string;
  primerCorte: number;
  segundoCorte: number;
  tercerCorte: number;
  definitiva: number;
}
