using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos.Event;

namespace GatherWise.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventResponseDto>> GetAll();
        Task<EventResponseDto> GetEventByIdAsync(Guid eventId);
        Task<EventResponseDto> Create(CreateEventDto dto);
    }
}