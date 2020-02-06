using System;
using FluentValidation;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Validators
{
    public class WhateverModelValidator : AbstractValidator<WhateverModel>
    {
        public WhateverModelValidator()
        {
            RuleFor(x => x)
               .NotNull().WithMessage("Objeto Whatever não informado.");

            RuleFor(x => x.Id)
               .NotEqual(Guid.Empty).WithMessage("Identificador inválido.");

            RuleFor(x => x.Name)
               .NotNull().WithMessage("Nome deve ser informado.")
               .NotEmpty().WithMessage("O Nome deve ser informado.");

            RuleForEach(x => x.Things)
               .InjectValidator();
        }
    }
}