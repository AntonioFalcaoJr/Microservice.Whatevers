using System;
using System.Collections.Generic;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Interfaces;
using Microservice.Whatevers.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class WhateversController : WhateverControllerBase
    {
        private readonly IWhateverService _whateverService;

        public WhateversController(IWhateverService whateverService) => _whateverService = whateverService;

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_whateverService.Exists(id)) return NotFound();

            _whateverService.Delete(id);
            return Accepted();
        }

        [HttpGet]
        public ActionResult<IEnumerable<WhateverModel>> GetAll()
        {
            var whatevers = _whateverService.GetAll();
            if (whatevers is {Count: 0}) return NoContent();

            return Ok(whatevers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");

            var whatever = _whateverService.GetById(id);
            if (whatever is null) return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WhateverModel model)
        {
            var whatever = _whateverService.Save(model);

            return CreatedAtAction(nameof(GetById),
                new {id = whatever.Id, version = HttpContext.GetRequestedApiVersion().ToString()},
                whatever);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] WhateverModel model)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");
            if (model?.Id != id) return BadRequest("Identificador diverge do objeto solicitado.");

            var whatever = _whateverService.Edit(model);
            return Ok(whatever);
        }
    }
}