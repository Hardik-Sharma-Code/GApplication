import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [];

  constructor(private employeesServices:EmployeesService, private router:Router) {
      
  }

  ngOnInit(): void {
    this.employeesServices.getAllEmployees().subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error:(response) => console.log(response)
    })
  }

  deleteEmployees(id:number){
    this.employeesServices.deleteEmployee(id).subscribe({
      next: (response) =>
      this.ngOnInit()
    })
  }
}
