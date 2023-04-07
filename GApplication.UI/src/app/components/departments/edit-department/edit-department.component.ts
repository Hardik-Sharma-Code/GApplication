import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from 'src/app/models/department.model';
import { DepartmentsService } from 'src/app/services/departments.service';
import { ValidateDataService } from 'src/app/services/validate-data.service';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent implements OnInit {

  departmentsDetails: Department = {
    departmentID: 0,
    departmentName: '',
  }
  result: any;
  constructor(private route: ActivatedRoute, private departmentService: DepartmentsService, private router: Router, private validateDataService: ValidateDataService) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')

        if (id) {
          this.departmentService.getDepartmentByID(id).subscribe({
            next: (response) => {
              this.departmentsDetails = response
            }
          })
        }
      }
    })
  }

  updateDepartment() {
    this.result = this.validateDataService.validDepartment(this.departmentsDetails);
    if (!this.result.IsValid) {
      return;
    }
    else {
      this.departmentService.updateDepartment(this.departmentsDetails)
        .subscribe({
          next: (response =>
            this.router.navigate(['/department'])
          )
        })
    }
  }
}
