import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { ValidateDataService } from 'src/app/services/validate-data.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnInit {

  addDepartmentRequest: Department = {
    departmentID: 0,
    departmentName: "",
  }

  allErrors: any;
  constructor(private departmentService: DepartmentsService, private router: Router, private validateDataService: ValidateDataService) {

  }

  ngOnInit(): void {

  }
  addDepartment() {

    let result = this.validateDataService.validDepartment(this.addDepartmentRequest);
    this.allErrors = result.Errors;
    if (!result.IsValid) {
      return this.allErrors;
    }
    else {
      this.departmentService.addDepartment(this.addDepartmentRequest).subscribe({
        next: (department) => {
          this.router.navigate(['/department'])
        }
      })
    }
  }
}

