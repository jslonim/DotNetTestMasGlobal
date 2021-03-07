import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../shared/Entities/employee';
import { environment } from './../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class EmployeeSearchService {

  private backendURL = environment.backendURL + 'api/Employee/';

  constructor(private http: HttpClient) { }

  GetAllEmployees(){
    return this.http.get<Employee[]>(this.backendURL + 'GetEmployees');
  }

  GetEmployeeById(id : number){
    return this.http.get<Employee>(this.backendURL + 'GetEmployeeById/' + id);
  }
}
