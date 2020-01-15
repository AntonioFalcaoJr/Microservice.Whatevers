using Microservice.Whatevers.Data.Repositories;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services.Services
{
    public class WhateverService : BaseService<Whatever>, IWhateverService
    {
        public WhateverService(IWhateverRepository whateverRepository) 
        : base(whateverRepository) { }
    }
}