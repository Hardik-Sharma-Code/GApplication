import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { DepartmentValidator } from '../../Validators/departmentvalidator.component';
import {
  IValidator,
  Validator,
  ValidationResult
} from "ts.validator.fluent/dist";
@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnInit {

  addDepartmentRequest: Department = {
    departmentID: 0,
    departmentName:'',
  }
  departmentValidator:DepartmentValidator;
  rules:any;
  result: ValidationResult;
  constructor(private departmentService:DepartmentsService,private router:Router) {
    
  }

  

  ngOnInit(): void {

  }

  addDepartment(){
    this.rules = (validator: IValidator<Department>): ValidationResult => {
      return validator
        .IsEmpty(m => m.departmentName, "First name must be empty").ToResult();
    };
  
    this. result = new Validator(this.addDepartmentRequest).Validate(this.rules);
    if(this.result.IsValid)
{
return;
}
else
{
  this.departmentService.addDepartment(this.addDepartmentRequest).subscribe({
    next:(department) => {
      this.router.navigate(['/department'])
    }})
  }
}}

