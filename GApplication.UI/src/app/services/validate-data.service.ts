import { Injectable } from '@angular/core';
import { IValidator, ValidationResult, Validator } from 'ts.validator.fluent/dist';
import { Department } from '../models/department.model';
import { Employee } from '../models/employee.model';
import { count } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidateDataService{

  result: any;
  constructor() { }

public validDepartment(department:Department){

  let rules = (validator: IValidator<Department>): ValidationResult => {
    return validator
    .NotEmpty((x) => x.departmentName, 'Please enter the Department')
    .ToResult()
  };
  this.result = new Validator(department).Validate(rules);

  return this.result;
}

public validEmployee(employee:Employee){

  let rules = (validator: IValidator<Employee>): ValidationResult => {
    return validator
    .NotEmpty((x) => x.firstName, 'Please enter the First name')
    .NotEmpty((x) => x.lastName, 'Please enter the Last name')
    .NotEmpty((x) => x.occupation, 'Please enter the Occupation')
    .NotEmpty((x) => x.eDepartment, 'Please select department')
    .NotEmpty((x) => x.gender, 'Please select gender')
    .If((x) => x.employeeType.length == 0  ,validator => validator.IsNull(x=>x.employeeType,"Please select atleast one type").ToResult())
    .ToResult()
  };
  this.result = new Validator(employee).Validate(rules);
  return this.result;
}
  
}
