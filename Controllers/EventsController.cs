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
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            var createdEvent = await _repo.Create(dto);
            return Ok(createdEvent);
        }

    }
}