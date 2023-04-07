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
        [Route("EmployeeById/{Id}")]
        public async Task<IActionResult> GetEmployeesById([FromRoute] int Id)
        {
            var result = await employees.GetEmployeesById(Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeesVM model)
        {   
            ValidationResult validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return Ok(validation);
            }
            var result =await employees.AddOrUpdate(model);
                return Ok(result);
        }
        [HttpPut]
        [Route("updateEmployee")]
        public async Task<IActionResult> updateEmployee([FromBody] EmployeesVM model)
        {
            ValidationResult validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return Ok(validation);
            }
            var result = await employees.AddOrUpdate(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteEmployee/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var getEmployee = await employees.GetEmployeesById(Id);
            var result = await employees.Delete(getEmployee);
            return Ok(result);
        }
    }
}
