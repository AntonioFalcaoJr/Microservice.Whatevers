using System;
using FluentValidation;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Validators
{
    public class ThingModelValidator : AbstractModelValidator<ThingModel>
    {
        public ThingModelValidator()
        {
            RuleFor(x => x)
               .NotNull().WithMessage("Objeto Thing não informado.");
            
            RuleFor(x => x.Id)
               .NotEqual(Guid.Empty).WithMessage("Identificador inválido");

            RuleFor(x => x.Name)
               .NotNull().WithMessage("Nome para Thing deve ser informado")
               .NotEmpty().WithMessage("Nome para Thing deve ser informado");

            RuleFor(x => x.Value)
               .GreaterThan(1000)
               .WithMessage("Valor maximo para Value deve ser 1000");
        }
    }
}