import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from 'src/enviroments/enviroment';
import { Department } from '../models/department.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  baseApiUrl: string = enviroment.baseApiURL;
  constructor(private http: HttpClient) { }

  getAllDepartment():Observable<Department[]>{
    {
      return this.http.get<Department[]>(this.baseApiUrl + 'api/Department/allDepartment');
    }
  }

  addDepartment(addDepartmentRequest:Department):Observable<Department>{
    addDepartmentRequest.departmentID = 0;
    return this.http.post<Department>(this.baseApiUrl + 'api/Department/addDepartment',addDepartmentRequest)
  }

  getDepartmentByID(id:string):Observable<Department>{
    return this.http.get<Department>(this.baseApiUrl + 'api/Department/DepartmentById/' + id)
  }

  updateDepartment(updateDepartment:Department):Observable<Department>{
    return this.http.put<Department>(this.baseApiUrl + 'api/Department/UpdateDeparment',updateDepartment)
  }

}
