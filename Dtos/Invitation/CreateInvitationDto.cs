using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatherWise.Dtos
{
    public class CreateInvitationDto
    {
        public Guid EventId { get; set; }
        public string Email { get; set; }
    }
}