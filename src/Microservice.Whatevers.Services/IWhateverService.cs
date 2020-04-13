using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public interface IWhateverService : IService<Whatever, WhateverModel, Guid> { }
}