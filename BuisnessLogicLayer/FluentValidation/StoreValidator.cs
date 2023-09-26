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

    public class StoreValidator : AbstractValidator<StoreDTO>
    {
        public StoreValidator()
        {
            RuleFor(s => s.Id).NotEmpty().GreaterThan(0);
            RuleFor(s => s.StoreName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Address).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Phone).NotEmpty().MaximumLength(20);
            RuleFor(s => s.WorkingHours).NotEmpty().MaximumLength(50);
        }
    }

}
