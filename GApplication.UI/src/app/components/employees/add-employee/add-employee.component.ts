import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { EmpTypeEnum } from 'src/app/models/emp-type-enum';
import { Employee } from 'src/app/models/employee.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { EmployeesService } from 'src/app/services/employees.service';
import { ValidateDataService } from 'src/app/services/validate-data.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  addEmployeeRequest: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    occupation: '',
    eDepartment: '',
    gender: '',
    employeeType: [],
    employeeTypeLists: []
  }

  departments: Department[] = [];
  result: any;
  empTypes = Object.values(EmpTypeEnum);
  allErrors: any;
  employeeNameError: any;
  constructor(private employeeService: EmployeesService, private departmentServices: DepartmentsService, private router: Router, private validateDataService: ValidateDataService) {
    this.initialization();
  }
  initialization() {

  }

  onSelected(value: string): void {
    this.addEmployeeRequest.eDepartment = value;
  }

  onCheckboxChange(event: any) {
    if (event.target.checked) {
      this.addEmployeeRequest.employeeType.push(event.target.value);
    }
    else {
      const index = this.addEmployeeRequest.employeeType.findIndex(x => x.value === event.target.value);
      this.addEmployeeRequest.employeeType.splice(index);
    }
  }
  ngOnInit(): void {
    console.log(this.empTypes);

    this.departmentServices.getAllDepartment().subscribe({
      next: (department) => {
        this.departments = department;
        console.log(department)
      },
      error: (response) => console.log(response)
    })

  }

  addEmployee() {

    this.result = this.validateDataService.validEmployee(this.addEmployeeRequest);
    this.allErrors = this.result.Errors;
    if (!this.result.IsValid) {
      return this.allErrors;
    }
    else {
      this.employeeService.addEmployee(this.addEmployeeRequest).subscribe({
        next: (employee) => {
          this.router.navigate(['/employees'])
        }
      })
    }
  }

}
