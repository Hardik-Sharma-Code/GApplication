using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.Service.Repository.Interface
{
    public interface IEmployeesServices
    {
        Task<EmployeesVM> GetEmployeesById(int id);
        Task<IList<EmployeesVM>> GetEmployees();
        Task<Employees> AddOrUpdate(EmployeesVM model);
        Task<Employees> Delete(EmployeesVM model);
    }
}
