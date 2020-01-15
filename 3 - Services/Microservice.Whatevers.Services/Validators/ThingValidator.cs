using FluentValidation;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services.Validators
{
    public class ThingValidator : AbstractValidator<Thing>
    {
        public ThingValidator()
        {
            RuleFor(x => x.Name)
            .NotNull().WithMessage("Nome para Thing deve ser informado")
            .NotEmpty().WithMessage("Nome para Thing deve ser informado");

            RuleFor(x => x.Value).GreaterThan(1000).WithMessage("Valor maximo para Value deve ser 1000");
        }
    }
}