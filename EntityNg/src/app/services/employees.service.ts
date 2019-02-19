import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  url = 'http://localhost:5000/employees';

  constructor(private http: HttpClient) { }


  getEmployeesObserve(): Observable<any> {
    return this.http.get(this.url);
  }
}
