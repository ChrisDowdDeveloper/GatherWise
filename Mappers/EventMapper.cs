using GatherWise.Models;
using GatherWise.Dtos.Event;

namespace GatherWise.Mappers
{
    public class EventMapper
    {
        public static EventResponseDto ToDto(EventModel model)
        {
            return new EventResponseDto
            {
                Id = model.Id,
                Name = model.Name,
                Date = model.Date,
                Location = model.Location,
                Details = model.Details,
                CreatedAt = model.CreatedAt
            };
        }

        public static EventModel ToModel(CreateEventDto dto)
        {
            return new EventModel
            {
                Name = dto.Name,
                Date = dto.Date,
                Location = dto.Location,
                Details = dto.Details,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
