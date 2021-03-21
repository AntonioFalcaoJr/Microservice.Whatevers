using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories.Abstractions;
using Microservice.Whatevers.Repositories.Contexts;

namespace Microservice.Whatevers.Repositories
{
    public class WhateverRepository : Repository<Whatever, Guid>, IWhateverRepository
    {
        public WhateverRepository(WhateverContext whateverContext)
            : base(whateverContext) { }
    }
}