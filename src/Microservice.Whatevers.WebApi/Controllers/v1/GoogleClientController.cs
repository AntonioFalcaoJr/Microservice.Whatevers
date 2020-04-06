using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class GoogleClientController : WhateverControllerBase
    {
        private readonly IGoogleClientService _googleClientService;

        public GoogleClientController(IGoogleClientService googleClientService) =>
            _googleClientService = googleClientService;

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var googleClientModel = await _googleClientService.GetAsync(cancellationToken);
            if (googleClientModel.IsValid()) return Ok(googleClientModel);
            return BadRequest(googleClientModel.GetErrors());
        }
    }
}