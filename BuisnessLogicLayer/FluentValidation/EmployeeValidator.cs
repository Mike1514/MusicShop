using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository.DTO;
using FluentValidation;

namespace BuisnessLogicLayer.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Id).NotEmpty().GreaterThan(0);
            RuleFor(e => e.LastName).NotEmpty().MaximumLength(50);
            RuleFor(e => e.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(e => e.MiddleName).NotEmpty().MaximumLength(50);
            RuleFor(e => e.DateOfBirth).NotEmpty();
            RuleFor(e => e.StoreId).NotEmpty().GreaterThan(0);
            RuleFor(e => e.Position).NotEmpty();
        }
    }
}
