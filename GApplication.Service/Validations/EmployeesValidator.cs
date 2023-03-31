using FluentValidation;
using GApplication.DATA.Model;
using GApplication.DATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.Service.Validations
{
    public class EmployeesValidator:AbstractValidator<EmployeesVM>
    {
        public EmployeesValidator()
        {
            RuleFor(e => e.FirstName).NotNull().NotEmpty().WithMessage("First Name is required");
            RuleFor(e => e.LastName).NotNull().NotEmpty().WithMessage("Last Name is required");
            RuleFor(e => e.Occupation).NotNull().NotEmpty().WithMessage("Occupation is required");
            RuleFor(e => e.Department).NotNull().NotEmpty().WithMessage("Department is required");
        }
    }
}
