using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department> FindByNameAsync(string name);
    }
}
