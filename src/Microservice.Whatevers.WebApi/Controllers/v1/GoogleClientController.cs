using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class GoogleClientController : WhateverControllerBase
    {
        private readonly IGoogleService _googleService;

        public GoogleClientController(IGoogleService googleService)
        {
            _googleService = googleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken) =>
            Ok(await _googleService.GetAsync(cancellationToken));
    }
}