using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos.Event;
using GatherWise.Interfaces;
using GatherWise.Mappers;
using GatherWise.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<EventResponseDto> Create(CreateEventDto dto, IFormFile file)
        {
            string fileUrl = null;

            if (file != null && file.Length > 0)
            {
                var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                var extension = Path.GetExtension(file.FileName);
                var fileName = $"event-{timestamp}{extension}";
                var storagePath = $"events/{fileName}";

                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var response = await _supabase.Storage
                    .From("event-pictures")
                    .Upload(storagePath, tempFilePath);

                File.Delete(tempFilePath);

                if (!string.IsNullOrEmpty(response))
                {
                    fileUrl = _supabase.Storage
                        .From("event-pictures")
                        .GetPublicUrl(storagePath);
                }
                else
                {
                    throw new Exception("Failed to upload file: Supabase response was empty.");
                }
            }

            var model = EventMapper.ToModel(dto);
            model.ImageUrl = fileUrl;

            var result = await _supabase.From<EventModel>().Insert(model);

            return EventMapper.ToDto(result.Models.First());
        }

        public async Task<bool> DeleteEventById(Guid eventId)
        {
            var result = await _supabase.From<EventModel>().Where(e => e.Id == eventId).Get();
            var model = result.Models.FirstOrDefault();
            if (model == null)
            {
                Console.WriteLine("Model not found");
                return false;
            }

            try
            {
                await model.Delete<EventModel>();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete failed: {ex.Message}");
                return false;
            }
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

            if (model == null)
            {
                return null;
            }

            return EventMapper.ToDto(model);
        }

        public async Task<EventResponseDto> Update(Guid eventId, UpdateEventDto dto)
        {
            var result = await _supabase.From<EventModel>().Where(e => e.Id == eventId).Get();
            var model = result.Models.FirstOrDefault();

            if (model == null)
            {
                return null;
            }

            model.Name = dto.Name ?? model.Name;
            model.Date = dto.Date ?? model.Date;
            model.Location = dto.Location ?? model.Location;
            model.Details = dto.Details ?? model.Details;

            await _supabase.From<EventModel>().Update(model);

            return EventMapper.ToDto(model);
        }
    }
}
