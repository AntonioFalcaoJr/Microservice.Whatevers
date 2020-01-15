using Microsoft.AspNetCore.Mvc;
using Microservice.Whatevers.Services.Services;
using Microservice.Whatevers.Domain.Entities;
using System.Collections.Generic;
using Microservice.Whatevers.Services.Validators;

namespace Microservice.Whatevers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhateverController : ControllerBase
    {
        private readonly IWhateverService _whateverService;

        public WhateverController(IWhateverService whateverService)
        {
            _whateverService = whateverService;
        }

        [HttpGet]
        public IEnumerable<Whatever> Get() => _whateverService.Get();

        [HttpPost]
        public IActionResult Post([FromBody] Whatever whatever)
        {

            if (whatever is null)
                return BadRequest("Objeto não informado");

            _whateverService.Save<WhateverValidator>(whatever);

            return new ObjectResult(whatever.Id);
        }

    }
}