import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IEmpresa } from './empresas.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpresasService {

  apiURL = this.baseUrl + "api/EmpresasController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEmpresas(): Observable<IEmpresa[]> {
    return this.http.get<IEmpresa[]>(this.apiURL);
  }
}
