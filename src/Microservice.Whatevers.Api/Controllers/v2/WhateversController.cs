using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.Api.Controllers.v2
{
    [ApiVersion("2")]
    public class WhateversController : WhateverControllerBase
    {
        private readonly IWhateverService _whateverService;

        public WhateversController(IWhateverService whateverService) => _whateverService = whateverService;

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!await _whateverService.ExistsAsync(id, cancellationToken)) return NotFound();

            await _whateverService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhateverModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var whatevers = await _whateverService.GetAllAsync(cancellationToken);
            if (whatevers is {Count: 0}) return NoContent();

            return Ok(whatevers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");

            var whatever = await _whateverService.GetByIdAsync(id, cancellationToken);
            if (whatever is null) return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] WhateverModel model, CancellationToken cancellationToken)
        {
            var whatever = await _whateverService.SaveAsync(model, cancellationToken);

            return CreatedAtAction(nameof(GetByIdAsync),
                new {id = whatever.Id, cancellationToken, version = HttpContext.GetRequestedApiVersion()},
                whatever);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] WhateverModel model, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");
            if (model?.Id != id) return BadRequest("Identificador diverge do objeto solicitado.");

            var whatever = await _whateverService.EditAsync(model, cancellationToken);
            return Ok(whatever);
        }
    }
}