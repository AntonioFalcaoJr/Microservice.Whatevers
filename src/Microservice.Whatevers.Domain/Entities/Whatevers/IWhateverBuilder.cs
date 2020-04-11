using System;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public interface IWhateverBuilder
    {
        IWhateverBuilder WithName(string name);
        IWhateverBuilder WithType(string type);
        IWhateverBuilder WithTime(DateTime time);
    }
}