import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './components/employees/employee-list/employees-list.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { EditEmployeesComponent } from './components/employees/edit-employees/edit-employees.component';
import { DepartmentListComponent } from './components/departments/department-list/department-list.component';
import { AddDepartmentComponent } from './components/departments/add-department/add-department.component';
import { EditDepartmentComponent } from './components/departments/edit-department/edit-department.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    AddEmployeeComponent,
    EditEmployeesComponent,
    DepartmentListComponent,
    AddDepartmentComponent,
    EditDepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
