import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDocente } from './docentes.component';

@Injectable({
  providedIn: 'root'
})
export class DocentesService {

  apiURL = this.baseUrl + "api/DocentesController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDocentes(): Observable<IDocente[]> {
    return this.http.get<IDocente[]>(this.apiURL);
  }
}
