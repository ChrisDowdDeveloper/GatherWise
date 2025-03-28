using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos.Event;
using GatherWise.Interfaces;
using GatherWise.Mappers;
using GatherWise.Models;
using Supabase;

namespace GatherWise.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Client _supabase;

        public EventRepository(Client supabase)
        {
            _supabase = supabase;
        }
        public async Task<EventResponseDto> Create(CreateEventDto dto)
        {
            var model = EventMapper.ToModel(dto);
            var result = await _supabase.From<EventModel>().Insert(model);
            return EventMapper.ToDto(result.Models.First());
        }

        public async Task<IEnumerable<EventResponseDto>> GetAll()
        {
            var result = await _supabase.From<EventModel>().Get();
            return result.Models.Select(EventMapper.ToDto);
        }

        public async Task<EventResponseDto> GetEventByIdAsync(Guid eventId)
        {
            var result = await _supabase.From<EventModel>().Where(e => e.Id == eventId).Get();

            var model = result.Models.FirstOrDefault();

            if(model == null)
            {
                return null;
            }

            return EventMapper.ToDto(model);
        }
    }
}