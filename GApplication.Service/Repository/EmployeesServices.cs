using GApplication.DATA.BaseRepositry;
using GApplication.DATA.Enums;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using GApplication.Service.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GApplication.DATA.Enums.getEnumName;

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
            ArrayList arrayList = new ArrayList();
            var _departmentID = await dept.FindByNameAsync(model.EDepartment);
            if (model.Id == 0)
            {
                _emp = new Employees
                {
                    DepartmentID = _departmentID.DepartmentID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Occupation = model.Occupation,
                    Gender = model.Gender,
                    EmployeeeType = string.Join(",", model.EmployeeType)

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
                _emp.Gender = model.Gender;
                _emp.EmployeeeType = string.Join(",", model.EmployeeType);
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
                                 EDepartment = d.DepartmentName,
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
                                 where (e.Id == id)
                                 select new EmployeesVM
                                 {
                                     Id = e.Id,
                                     EDepartment = d.DepartmentName,
                                     FirstName = e.FirstName,
                                     LastName = e.LastName,
                                     Occupation = e.Occupation,
                                     EmployeeType = e.EmployeeeType.Split(','),
                                     employeeTypeLists = GetEmployeeTypeLists(e.EmployeeeType),
                                     Gender = e.Gender,
                                 }).FirstOrDefault();
            return employeesByID;
        }


        #region privateMethods
        private List<EmployeeTypeList> GetEmployeeTypeLists(string employeesVM)
        {
            var list = new List<EmployeeTypeList>();

            foreach (var item in employeesVM.Split(','))
            {
                if (item == getEnumName.GetStringDescription(EmployeTypeEnum.FullTime) || item == getEnumName.GetStringDescription(EmployeTypeEnum.PartTime) || item == getEnumName.GetStringDescription(EmployeTypeEnum.FreeLancer))
                {
                    list.Add(new EmployeeTypeList { Name = item, IsSelected = true });
                }
            }
            var enumList = new DescriptionAttributes<EmployeTypeEnum>().Descriptions.ToList();

            foreach (var item in enumList)
            {
                var isExist = list.Any(x => x.Name == item);

                if (!isExist)
                {
                    list.Add(new EmployeeTypeList { Name = item, IsSelected = false });
                }
            }
            return list;
        }

        #endregion
    }
}
