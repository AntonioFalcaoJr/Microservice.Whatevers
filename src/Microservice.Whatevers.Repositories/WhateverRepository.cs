using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories.Base;
using Microservice.Whatevers.Repositories.Contexts;

namespace Microservice.Whatevers.Repositories
{
    public class WhateverRepository : BaseRepository<Whatever, Guid>, IWhateverRepository
    {
        public WhateverRepository(WhateverContext whateverContext)
            : base(whateverContext) { }
    }
}