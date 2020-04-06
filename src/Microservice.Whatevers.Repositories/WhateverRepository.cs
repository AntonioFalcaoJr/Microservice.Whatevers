using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Repositories.Base;
using Microservice.Whatevers.Repositories.Contexts;

namespace Microservice.Whatevers.Repositories
{
    public class WhateverRepository : BaseRepository<Whatever>, IWhateverRepository
    {
        public WhateverRepository(WhateverContext whateverContext)
            : base(whateverContext) { }
    }
}