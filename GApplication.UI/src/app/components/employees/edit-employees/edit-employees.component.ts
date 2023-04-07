import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { EmpTypeEnum } from 'src/app/models/emp-type-enum';
import { Employee } from 'src/app/models/employee.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { EmployeesService } from 'src/app/services/employees.service';
import { ValidateDataService } from 'src/app/services/validate-data.service';

@Component({
  selector: 'app-edit-employees',
  templateUrl: './edit-employees.component.html',
  styleUrls: ['./edit-employees.component.css']
})
export class EditEmployeesComponent implements OnInit {
  employTypeNew: any;
  departments: Department[] = [];
  employeesDetails: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    occupation: '',
    eDepartment: '',
    gender: '',
    employeeType: [],
    employeeTypeLists: []
  }
  allErrors: any;
  empTypes = Object.values(EmpTypeEnum);
  constructor(private route: ActivatedRoute, private employeeService: EmployeesService, private departmentServices: DepartmentsService, private router: Router, private validateDataService: ValidateDataService) {
    this.onCheckboxChange;
  }

  onSelected(value: string): void {
    this.employeesDetails.eDepartment = value;
  }


  onCheckboxChange(event: any) {

    if (event.target.checked) {
      this.employeesDetails.employeeType.push(event.target.value);
    }
    else {
      const index = this.employeesDetails.employeeType.findIndex(x => x.value === event.target.value);
      this.employeesDetails.employeeType.splice(index);
    }
  }

  ngOnInit(): void {

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')

        if (id) {
          this.employeeService.getEmployeeByID(id).subscribe({
            next: (response) => {
              this.employeesDetails = response
              console.log(response)
            }
          })
        }
      }
    })


    this.departmentServices.getAllDepartment().subscribe({
      next: (department) => {
        this.departments = department;
        console.log(department)
      },
      error: (response) => console.log(response)
    })

  }

  updateEmployee() {
    let result = this.validateDataService.validEmployee(this.employeesDetails);
    this.allErrors = result.Errors;
    if (!result.IsValid) {
      return this.allErrors;
    }
    else {
      this.employeeService.updateEmployee(this.employeesDetails)
        .subscribe({
          next: (response =>
            this.router.navigate(['/employees'])
          )
        })
    }
  }
}
