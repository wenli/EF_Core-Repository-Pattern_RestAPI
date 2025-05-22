using BrandApplication.Business.DTOs;
using BrandApplication.Business.Services.IServices;
using BrandApplication.Business.CustomExceptions; // For EntityNotFoundException
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For StatusCodes
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandApplication.API.Controllers // Standard namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BtStrategyController : ControllerBase
    {
        private readonly IBtStrategyService _service;

        public BtStrategyController(IBtStrategyService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BtStrategyDto>>> GetAllStrategies()
        {
            var strategies = await _service.GetAllStrategiesAsync();
            return Ok(strategies);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BtStrategyDto>> GetStrategyById(int id)
        {
            if (id <= 0) // Basic validation
            {
                return BadRequest("Id must be greater than 0.");
            }
            try
            {
                var strategyDto = await _service.GetStrategyByIdAsync(id);
                return Ok(strategyDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BtStrategyDto>> CreateStrategy([FromBody] BtStrategyDto strategyDto)
        {
            if (strategyDto == null)
            {
                return BadRequest("Strategy DTO cannot be null.");
            }
            // Optional: Add ModelState.IsValid check if using data annotations for validation in DTO
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            var createdStrategy = await _service.CreateStrategyAsync(strategyDto);
            return CreatedAtAction(nameof(GetStrategyById), new { id = createdStrategy.Id }, createdStrategy);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStrategy(int id, [FromBody] BtStrategyDto strategyDto)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0.");
            }
            if (strategyDto == null) // || id != strategyDto.Id if Id is expected in body and must match route
            {
                return BadRequest("Strategy DTO cannot be null or ID mismatch.");
            }

            // Optional: Add ModelState.IsValid check
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            
            try
            {
                await _service.UpdateStrategyAsync(id, strategyDto);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteStrategy(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0.");
            }
            try
            {
                await _service.DeleteStrategyAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
