import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { DepartmentsService } from 'src/app/services/departments.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  departments: Department[] = [];

  constructor(private departmentServices: DepartmentsService) {
      
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
}