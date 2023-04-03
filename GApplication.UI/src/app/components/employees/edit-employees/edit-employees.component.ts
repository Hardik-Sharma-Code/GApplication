import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-employees',
  templateUrl: './edit-employees.component.html',
  styleUrls: ['./edit-employees.component.css']
})
export class EditEmployeesComponent implements OnInit {

  employeesDetails: Employee = {
    id:0,
    firstName: '',
    lastName: '',
    occupation: '',
    eDepartment: ''
  }
  constructor(private route:ActivatedRoute,private employeeService: EmployeesService, private router:Router ) {
    
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params) => {
      const id =   params.get('id')

      if(id)
      {
this.employeeService.getEmployeeByID(id).subscribe({
  next: (response) => {
this.employeesDetails = response
  }
})
      }
      }
    })
  }

  updateEmployee(){
    this.employeeService.updateEmployee(this.employeesDetails)
    .subscribe({next: (response => 
      this.router.navigate(['/employees'])
      )})
  }
}
