import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { DepartmentsService } from 'src/app/services/departments.service';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent implements OnInit {

  departmentsDetails: Department = {
    departmentID:0,
    departmentName: '',
  }
  constructor(private route:ActivatedRoute,private departmentService: DepartmentsService, private router:Router ) {
    
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params) => {
      const id =   params.get('id')

      if(id)
      {
this.departmentService.getDepartmentByID(id).subscribe({
  next: (response) => {
this.departmentsDetails = response
  }
})
      }
      }
    })
  }

  updateDepartment(){
    this.departmentService.updateDepartment(this.departmentsDetails)
    .subscribe({next: (response => 
      this.router.navigate(['/department'])
      )})
  }
}
