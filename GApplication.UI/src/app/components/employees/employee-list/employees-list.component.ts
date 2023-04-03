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
  filteredArray: any;
  constructor(private employeesServices:EmployeesService, private router:Router) {
      
  }
  ngOnInit(): void {
    this.filteredArray = [];
    this.employeesServices.getAllEmployees().subscribe({
      next: (employees) => {
        this.employees = employees;
        this.filteredArray = employees;
      },
      error:(response) => console.log(response)
    });

  
  }

  applyFilter(event: any) {

      if (!this.employees.length) {
        this.filteredArray = [];
        return;
      }
  
      if (!event.target.value) {      
        this.filteredArray = [...this.employees]; 
        return;
      }
  
      const users = [...this.employees]; 
      const properties = Object.keys(users[0]); 
  
      this.filteredArray =  users.filter((user) => {
        return properties.find((property) => {
          const valueString = user.firstName.toString().toLowerCase();
          const lastName = user.lastName.toString().toLowerCase();
          return valueString.includes(event.target.value.toLowerCase()) || lastName.includes(event.target.value.toLowerCase());
        })
        ? user
        : null;
      });
  }


  deleteEmployees(id:number){
    this.employeesServices.deleteEmployee(id).subscribe({
      next: (response) =>
      this.ngOnInit()
    })
  }
}
