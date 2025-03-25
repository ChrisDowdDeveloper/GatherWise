using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatherWise.Dtos.Event
{
    public class EventResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}