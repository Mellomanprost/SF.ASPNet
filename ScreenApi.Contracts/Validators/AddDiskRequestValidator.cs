using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ScreenApi.Contracts.Models;

namespace ScreenApi.Contracts.Validators
{
    public class AddDiskRequestValidator : AbstractValidator<AddDiskRequest>
    {
        public AddDiskRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Capacity).Must(BeValidCapacity).WithMessage("Поддерживаются диски объемом от 120 до 512 Гб.");

        }

        private bool BeValidCapacity(int capacity)
        {
            if(capacity < 120)
                return false;

            if(capacity > 512)
                return false;

            return true;
        }
    }
}
