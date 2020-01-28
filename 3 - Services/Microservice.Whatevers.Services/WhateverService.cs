using AutoMapper;
using Microservice.Whatevers.Data.Repositories;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public class WhateverService : BaseService<Whatever, WhateverModel>, IWhateverService
    {
        public WhateverService(IWhateverRepository whateverRepository, IMapper mapper) 
        : base(whateverRepository, mapper) { }
    }
}