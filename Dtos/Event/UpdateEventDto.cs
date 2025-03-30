using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatherWise.Dtos.Event
{
    public class UpdateEventDto
    {
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Details { get; set; }
    }
}