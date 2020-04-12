using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public interface IWhateverBuilder : IBuilder<Whatever, Guid>
    {
        IWhateverBuilder WithName(string name);
        IWhateverBuilder WithTime(DateTime time);
        IWhateverBuilder WithType(string type);
    }
}