using Microservice.Whatevers.Services.Validators;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Microservice.Whatevers.Api.Controllers
{
    [ApiController,Route("[controller]")]
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
        public async Task<ActionResult<IEnumerable<Whatever>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _whateverService.GetAllAsync(cancellationToken);

            if (result is null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty) return BadRequest();

            var whatever = await _whateverService.GetByIdAsync(id, cancellationToken);

            if (whatever is null) return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Whatever whatever, CancellationToken cancellationToken)
        {
            if (whatever is null) return BadRequest();
            
            var validationResult = await _validator.ValidateAsync(whatever,cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _whateverService.SaveAsync(whatever, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = whatever.Id }, whatever);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Whatever whatever, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest();
            if (whatever?.Id != id) return BadRequest();
            
            var validationResult = await _validator.ValidateAsync(whatever, cancellationToken);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            
            await _whateverService.EditAsync(whatever, cancellationToken);
            return Ok(whatever);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty) return BadRequest();

            var whatever = _whateverService.GetByIdAsync(id, cancellationToken);

            if (whatever is null) return NotFound();

            await _whateverService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}