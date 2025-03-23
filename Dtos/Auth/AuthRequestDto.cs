using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatherWise.Dtos
{
    public class AuthRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}