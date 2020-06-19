import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEstudiante } from './estudiantes.component';

@Injectable({
  providedIn: 'root'
})
export class EstudiantesService {

  apiURL = this.baseUrl + "api/EstudiantesController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEstudiantes(): Observable<IEstudiante[]> {
    return this.http.get<IEstudiante[]>(this.apiURL);
  }
}
