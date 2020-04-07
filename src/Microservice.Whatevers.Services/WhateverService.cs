using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories;
using Microservice.Whatevers.Services.Interfaces;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public class WhateverService : ServiceBase<Whatever, WhateverModel>, IWhateverService
    {
        public WhateverService(IWhateverRepository whateverRepository, IMapper mapper)
            : base(whateverRepository, mapper) { }
    }
}