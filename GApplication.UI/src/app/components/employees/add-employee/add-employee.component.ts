import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { Employee } from 'src/app/models/employee.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  addEmployeeRequest: Employee = {
    id: 0,
    firstName:'',
    lastName:'',
    occupation:'',
    eDepartment:''
  }

  departments: Department[] = [];
  oppoSuitsForm: FormGroup;
  constructor(private employeeService:EmployeesService, private departmentServices:DepartmentsService, private router:Router) {
      this.initialization();
  }
  initialization()
  {
this.oppoSuitsForm = new FormGroup({

})
  }
  ngOnInit(): void {
    this.departmentServices.getAllDepartment().subscribe({
      next: (department) => {
        this.departments = department;
        console.log(department)
      },
      error:(response) => console.log(response)
    })
  }

  addEmployee(){
this.employeeService.addEmployee(this.addEmployeeRequest).subscribe({
  next:(employee) => {
    this.router.navigate(['/employees'])
  }})
}

}
