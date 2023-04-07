import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [];
  filteredEmployeeList: any;
  constructor(private employeesServices: EmployeesService, private router: Router) {

  }
  ngOnInit(): void {
    this.filteredEmployeeList = [];
    this.employeesServices.getAllEmployees().subscribe({
      next: (employees) => {
        this.employees = employees;
        this.filteredEmployeeList = employees;
      },
      error: (response) => console.log(response)
    });


  }

  applyFilter(event: any) {

    if (!this.employees.length) {
      this.filteredEmployeeList = [];
      return;
    }

    if (!event.target.value) {
      this.filteredEmployeeList = [...this.employees];
      return;
    }

    const empDetails = [...this.employees];
    const properties = Object.keys(empDetails[0]);

    this.filteredEmployeeList = empDetails.filter((empDetails) => {
      return properties.find((property) => {
        const valueString = empDetails.firstName.toString().toLowerCase();
        const lastName = empDetails.lastName.toString().toLowerCase();
        return valueString.includes(event.target.value.toLowerCase()) || lastName.includes(event.target.value.toLowerCase());
      })
        ? empDetails
        : null;
    });
  }


  deleteEmployees(id: number) {
    this.employeesServices.deleteEmployee(id).subscribe({
      next: (response) =>
        this.ngOnInit()
    })
  }
}
