import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISolicitud } from './solicitudes.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SolicitudesService {

  apiURL = this.baseUrl + "api/SolicitudesController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getSolicitudes(): Observable<ISolicitud[]> {
    return this.http.get<ISolicitud[]>(this.apiURL);
  }
}
