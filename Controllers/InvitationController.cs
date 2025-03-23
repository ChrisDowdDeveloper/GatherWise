using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInvitationDto dto)
        {
            var invitation = await _repo.Create(dto);
            return Ok(invitation);
        }
    }
}