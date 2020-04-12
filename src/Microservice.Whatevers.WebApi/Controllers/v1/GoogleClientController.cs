using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Abstractions;
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
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var googleClientModel = await _googleService.GetAsync(cancellationToken);
            if (googleClientModel.IsValid()) return Ok(googleClientModel);
            return BadRequest(googleClientModel.GetErrors());
        }
    }
}