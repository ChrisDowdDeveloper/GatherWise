using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GatherWise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationRepository _repo;

        public InvitationController(IInvitationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invitations = await _repo.GetAll();
            return Ok(invitations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvitationById(int id)
        {
            var invitation = await _repo.GetInvitationByIdAsync(id);

            if(invitation == null)
            {
                return NotFound();
            }

            return Ok(invitation);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetInvitationsByEventId(Guid eventId)
        {
            var invitations = await _repo.GetInvitationsByEventIdAsync(eventId);
            
            if(invitations.IsNullOrEmpty())
            {
                return BadRequest("No invitations were sent with this event");
            }

            return Ok(invitations);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInvitationDto dto)
        {
            var invitation = await _repo.Create(dto);
            return Ok(invitation);
        }

    }
}