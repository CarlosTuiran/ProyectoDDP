import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAdmin } from './admins.component';

@Injectable({
  providedIn: 'root'
})
export class AdminsService {

  apiURL = this.baseUrl + "api/AdminsController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAdmins(): Observable<IAdmin[]> {
    return this.http.get<IAdmin[]>(this.apiURL);
  }
}
