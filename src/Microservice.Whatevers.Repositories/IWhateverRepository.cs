using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories.Abstractions;

namespace Microservice.Whatevers.Repositories
{
    public interface IWhateverRepository : IRepository<Whatever, Guid> { }
}