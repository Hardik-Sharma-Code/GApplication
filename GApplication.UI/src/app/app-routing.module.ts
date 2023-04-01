import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employees/employee-list/employees-list.component';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EditEmployeesComponent } from './components/employees/edit-employees/edit-employees.component';

const routes: Routes = [{
  path:'',
  component: EmployeeListComponent
},
{
  path:'employees',
  component: EmployeeListComponent
},{
  path:'employees/add',
  component: AddEmployeeComponent
},
{
  path:'employees/edit/:id',
  component: EditEmployeesComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
