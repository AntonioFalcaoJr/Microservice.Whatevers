using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;

namespace Microservice.Whatevers.Api.Controllers
{
    [ApiController,Route("[controller]")]
    public class WhateverController : ControllerBase
    {
        private readonly IWhateverService _whateverService;

        public WhateverController(IWhateverService whateverService, IValidator<Whatever> validator)
        {
            _whateverService = whateverService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Whatever>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var whatevers = await _whateverService.GetAllAsync(cancellationToken);
            if (whatevers is {Count: 0}) return NoContent();

            return Ok(whatevers);
        }

        [HttpGet("{id}"),ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest();

            var whatever = await _whateverService.GetByIdAsync(id, cancellationToken);
            if (whatever is null) return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Whatever whatever, CancellationToken cancellationToken)
        {
            await _whateverService.SaveAsync(whatever, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = whatever.Id, cancellationToken }, whatever);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Whatever whatever, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id || whatever?.Id != id) return BadRequest();
            
            await _whateverService.EditAsync(whatever, cancellationToken);
            return Ok(whatever);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest();
            if (!await _whateverService.ExistsAsync(id, cancellationToken)) return NotFound();
            
            await _whateverService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}