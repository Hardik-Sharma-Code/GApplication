﻿using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public interface IEmployeesRepository : IBaseRepository<Employees>
    {
       //Task<EmployeesVM> GetEmployeesById(int id);
       //Task<IEnumerable<EmployeesVM>> GetEmployees();
       // Task<Employees> AddOrUpdate(EmployeesVM model);
    }
}
