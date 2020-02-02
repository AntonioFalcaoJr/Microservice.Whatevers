using Microservice.Whatevers.Data.Contexts;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Data.Repositories
{
    public class WhateverRepository : BaseRepository<Whatever>, IWhateverRepository
    {
        public WhateverRepository(WhateverContext dbContext)
            : base(dbContext) { }
    }
}