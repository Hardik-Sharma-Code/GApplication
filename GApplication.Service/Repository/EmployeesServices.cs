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
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IEmployeesRepository emp;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDepartmentRepository dept;

        public EmployeesServices(IEmployeesRepository employeesRepository,
            IUnitOfWork unitOfWork,
            IDepartmentRepository departmentRepository)
        {
            this.emp = employeesRepository;
            this.unitOfWork = unitOfWork;
            this.dept = departmentRepository;
        }
        public async Task<Employees> AddOrUpdate(EmployeesVM model)
        {
            Employees _emp = null;
            var _departmentID = await dept.FindByNameAsync(model.Department);
            if (model.Id == 0)
            {
                _emp = new Employees
                {
                    DepartmentID = _departmentID.DepartmentID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Occupation = model.Occupation
                };
                emp.Add(_emp);
            }
            else
            {
                _emp = emp.Find(x => x.Id == model.Id).FirstOrDefault();
                _emp.FirstName = model.FirstName;
                _emp.LastName = model.LastName;
                _emp.Occupation = model.Occupation;
                _emp.DepartmentID = _departmentID.DepartmentID;
                emp.Update(_emp);
            }
            await unitOfWork.SaveChangesAsync();
            return _emp;
        }

        public async Task<Employees> Delete(EmployeesVM model)
        {

            var _empDelete = emp.GetById(model.Id);
            emp.Remove(_empDelete);
            await unitOfWork.SaveChangesAsync();
            return _empDelete;
        }

        public async Task<IList<EmployeesVM>> GetEmployees()
        {
            var employees = (from e in emp.GetAll()
                                   join d in dept.GetAll() on e.DepartmentID equals d.DepartmentID
                                   select new EmployeesVM()
                                   {
                                       Id = e.Id,
                                       Department = d.DepartmentName,
                                       FirstName = e.FirstName,
                                       LastName = e.LastName,
                                       Occupation = e.Occupation,
                                   }).ToList();

            return employees;

        }

        public async Task<EmployeesVM> GetEmployeesById(int id)
        {
            var employeesByID = (from e in emp.GetAll()
                                       join d in dept.GetAll() on e.DepartmentID equals d.DepartmentID
                                       select new EmployeesVM()
                                       {
                                           Id = e.Id,
                                           Department = d.DepartmentName,
                                           FirstName = e.FirstName,
                                           LastName = e.LastName,
                                           Occupation = e.Occupation,
                                       }).FirstOrDefault();
            return employeesByID;
        }
    }
}
