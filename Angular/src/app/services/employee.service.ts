import { Injectable } fm '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/Employees';
import { Response } from '../models/Response';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private apiUrl = `${environment.ApiUrl}Employee`;

  constructor(private httpClient: HttpClient) {}

  GetEmployees(): Observable<Response<Employee[]>> {
    return this.httpClient.get<Response<Employee[]>>(this.apiUrl);
  }
  CreateEmployee(employee: Employee): Observable<Response<Employee[]>> {
    return this.httpClient.post<Response<Employee[]>>(this.apiUrl, employee);
  }
  GetEmployeeById(id: number): Observable<Response<Employee>> {
    return this.httpClient.get<Response<Employee>>(`${this.apiUrl}/${id}`);
  }
}
