using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Interfaces
{
    public interface IWhateverService : IService<Whatever, WhateverModel> { }
}