using FluentValidation;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services.Validators
{
    public interface IThingValidator : IValidator<Thing>
    {
         
    }
}