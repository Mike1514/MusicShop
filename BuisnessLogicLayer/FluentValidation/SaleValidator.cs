using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogicLayer.Models;
using DataAccessLayer.Repository.DTO;
using FluentValidation;

namespace BuisnessLogicLayer.FluentValidation
{
    public class SaleValidator : AbstractValidator<SaleDTO>
    {
        public SaleValidator()
        {
            RuleFor(s => s.Id).NotEmpty().GreaterThan(0);
            RuleFor(s => s.TransactionDate).NotEmpty();
            RuleFor(s => s.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(s => s.StoreId).NotEmpty().GreaterThan(0);
            RuleFor(s => s.EmployeeId).NotEmpty().GreaterThan(0);
            RuleFor(s => s.Note).MaximumLength(100);
        }
    }
    







}
