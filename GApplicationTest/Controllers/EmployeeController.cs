using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using GApplication.DATA.BaseRepositry;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using GApplication.Service.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
namespace GApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesServices employees;
        private readonly IValidator<EmployeesVM> _validator;

        public EmployeeController(IEmployeesServices employees,IValidator<EmployeesVM> validator)
        {
            this.employees = employees;
            this._validator = validator;
        }
        [HttpGet]
        [Route("allEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await employees.GetEmployees();
            return Ok(result);
        }
        [HttpGet]
        [Route("EmployeeById")]
        public async Task<IActionResult> GetEmployeesById(int Id)
        {
            var result = await employees.GetEmployeesById(Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeesVM model)
        {   
            ValidationResult validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return Ok(validation);
            }
            var result =await employees.AddOrUpdate(model);
            return Ok("Data Save");
        }
        [HttpPut]
        [Route("updateEmployee")]
        public async Task<IActionResult> updateEmployee(EmployeesVM model)
        {
            if (model == null)
            {
                return BadRequest(Ok()); 

            }
            var result = await employees.AddOrUpdate(model);
            return Ok("Data Updated");
        }

        [HttpDelete]
        [Route("RemoveEmployee")]
        public async Task<IActionResult> Delete(EmployeesVM model)
        {
            var result = await employees.Delete(model);
            return Ok(result);
        }
    }
}
