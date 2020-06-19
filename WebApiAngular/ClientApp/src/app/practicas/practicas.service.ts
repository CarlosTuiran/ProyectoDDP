import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPractica } from './practicas.component';

@Injectable({
  providedIn: 'root'
})
export class PracticasService {

  apiURL = this.baseUrl + "api/PracticasController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPracticas(): Observable<IPractica[]> {
    return this.http.get<IPractica[]>(this.apiURL);
  }
}
