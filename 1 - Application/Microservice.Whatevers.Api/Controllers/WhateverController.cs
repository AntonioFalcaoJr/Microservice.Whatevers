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
        private readonly IWhateverValidator _validator;

        public WhateverController(IWhateverService whateverService, IWhateverValidator validator)
        {
            _whateverService = whateverService;
            _validator = validator;
        }

        [HttpGet]
        public IEnumerable<Whatever> Get() => _whateverService.Get();

        [HttpPost]
        public IActionResult Post([FromBody] Whatever whatever)
        {
            var validationResult = _validator.Validate(whatever);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _whateverService.Save(whatever);
            return new ObjectResult(whatever.Id);
        }
    }
}