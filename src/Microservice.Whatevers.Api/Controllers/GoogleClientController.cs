using System.Threading.Tasks;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.Api.Controllers
{    
    [ApiVersion("1")]
    public class GoogleClientController : WhateverControllerBase
    {
        private readonly IGoogleClientService _googleClientService;
    
        public GoogleClientController(IGoogleClientService googleClientService)
        {
            _googleClientService = googleClientService;
        }
        
        [HttpGet]
        public async Task<GoogleModel> GetAsync() => await _googleClientService.GetAsync();
    }
}