import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IConvenio } from './convenios.component';

@Injectable({
  providedIn: 'root'
})
export class ConveniosService {

  apiURL = this.baseUrl + "api/ConveniosController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getConvenios(): Observable<IConvenio[]> {
    return this.http.get<IConvenio[]>(this.apiURL);
  }
}
