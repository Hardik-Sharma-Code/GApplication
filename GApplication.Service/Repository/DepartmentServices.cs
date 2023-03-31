using GApplication.DATA.BaseRepositry;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using GApplication.Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.Service.Repository
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDepartmentRepository dept;

        public DepartmentServices(IUnitOfWork unitOfWork,
            IDepartmentRepository departmentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.dept = departmentRepository;
        }
        public async Task<Department> AddOrUpdate(Department model)
        {
            Department _dept = null;
            if (model.DepartmentID == 0)
            {
                _dept = new Department
                {
                    DepartmentName = model.DepartmentName,
                };
                dept.Add(_dept);
            }
            else
            {
                _dept = dept.Find(x => x.DepartmentID == model.DepartmentID).FirstOrDefault();
                _dept.DepartmentName = model.DepartmentName;
                dept.Update(_dept);
            }
            await unitOfWork.SaveChangesAsync();
            return _dept;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return dept.GetAll();

        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return dept.GetById(id);
        }
    }
}
