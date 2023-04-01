import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from 'src/enviroments/enviroment';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: string = enviroment.baseApiURL;
  constructor(private http: HttpClient) { }

  getAllEmployees():Observable<Employee[]>{
    {
      return this.http.get<Employee[]>(this.baseApiUrl + 'api/Employee/allEmployees');
    }
  }

  addEmployee(addEmployeeRequest:Employee):Observable<Employee>{
    addEmployeeRequest.id = 0;
    return this.http.post<Employee>(this.baseApiUrl + 'api/Employee/addEmployee',addEmployeeRequest)
  }

  getEmployeeByID(id:string):Observable<Employee>{
    return this.http.get<Employee>(this.baseApiUrl + 'api/Employee/EmployeeById/' + id)
  }

  updateEmployee(updateEmployee:Employee):Observable<Employee>{
    return this.http.put<Employee>(this.baseApiUrl + 'api/Employee/updateEmployee',updateEmployee)
  }

  
  deleteEmployee(id:number):Observable<Employee>{
    return this.http.delete<Employee>(this.baseApiUrl + 'api/Employee/deleteEmployee/' + id)
  }

}
