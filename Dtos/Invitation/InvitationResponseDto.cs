using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatherWise.Dtos
{
    public class InvitationResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime SentAt { get; set; }
    }
}