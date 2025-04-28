using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Dtos.Event;
using GatherWise.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace GatherWise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repo;

        public EventsController(IEventRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _repo.GetAll();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var foundEvent = await _repo.GetEventByIdAsync(id);
            
            if(foundEvent == null)
            {
                return NotFound();
            }

            return Ok(foundEvent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto, [FromForm] IFormFile file)
        {
            var createdEvent = await _repo.Create(dto, file);
            return Ok(createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] UpdateEventDto dto)
        {
            var updatedEvent = await _repo.Update(id, dto);
            return Ok(updatedEvent);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var deletedEvent = await _repo.DeleteEventById(id);
            if(deletedEvent)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Something went wrong.");
            }
        }

    }
}