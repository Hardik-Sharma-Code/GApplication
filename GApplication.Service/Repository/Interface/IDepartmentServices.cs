using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.Service.Repository.Interface
{
    public interface IDepartmentServices
    {
        Task<Department> GetDepartmentById(int id);
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> AddOrUpdate(Department model);
    }
}
