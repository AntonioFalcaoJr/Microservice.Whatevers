using System;
using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Repositories;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public class WhateverService : Service<Whatever, WhateverModel, Guid>, IWhateverService
    {
        public WhateverService(IWhateverRepository whateverRepository, IMapper mapper)
            : base(whateverRepository, mapper) { }
    }
}