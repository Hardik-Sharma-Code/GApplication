using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using GApplication.Service.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices department;
        private readonly IValidator<Department> _validator;

        public DepartmentController(IDepartmentServices department, IValidator<Department> validator)
        {
            this.department = department;
            _validator = validator;
        }

        [HttpGet]
        [Route("allDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            var result = await department.GetDepartment();
            return Ok(result);
        }
        [HttpGet]
        [Route("DepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int Id)
        {
            var result = await department.GetDepartmentById(Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddDeparment")]
        public async Task<IActionResult> AddDeparment(Department model)
        {
            ValidationResult validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return Ok(validation);
            }
            var result = await department.AddOrUpdate(model);
            return Ok("Data Save");
        }
        [HttpPut]
        [Route("UpdateDeparment")]
        public async Task<IActionResult> UpdateDeparment(Department model)
        {
            if (model == null)
            {
                return BadRequest(Ok());
            }
            var result = await department.AddOrUpdate(model);
            return Ok("Data Updated");
        }
    }
}
