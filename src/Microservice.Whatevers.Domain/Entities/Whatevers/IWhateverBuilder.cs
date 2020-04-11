using System;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public interface IWhateverBuilder
    {
        IWhateverBuilder WithName(string name);
        IWhateverBuilder WithTime(DateTime time);
        IWhateverBuilder WithType(string type);
    }
}