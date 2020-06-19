import { Component, OnInit } from '@angular/core';
import { EstudiantesService } from './estudiantes.service';

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css']
})
export class EstudiantesComponent implements OnInit {

  estudiantes: IEstudiante[];
  constructor(private estudiantesService: EstudiantesService) { }

  ngOnInit() {
    this.estudiantesService.getEstudiantes()
      .subscribe(estudiantes => this.estudiantes = estudiantes,
        error => console.error(error));
  }

}
export interface IEstudiante {
  
  email: string;
  nombres: string;
  apellidos: string;
  docIdentidad: number;
  carrera: string;
  celular: number;
  direccion: string;
  departamento: string;
  ciudad: string;
  telefono: number;
}
