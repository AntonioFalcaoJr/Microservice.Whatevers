using System;
using FluentValidation;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services.Validators
{
    public class WhateverValidator : AbstractValidator<Whatever>
    {
        public WhateverValidator()
        {
            RuleFor(x => x)
            .NotNull()
            .OnAnyFailure(x => throw new ArgumentNullException($"Objeto Whatever não localizado."));

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome deve ser informado")
            .NotNull().WithMessage("Nome deve ser informado");

            RuleForEach(x => x.Things).SetValidator(new ThingValidator());
        }
    }
}