using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Interfaces;
using GatherWise.Mappers;
using GatherWise.Models;
using Microsoft.VisualBasic;
using Supabase;

namespace GatherWise.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly Client _supabase;

        public InvitationRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<IEnumerable<InvitationResponseDto>> GetAll()
        {
            var result = await _supabase.From<Invitation>().Get();
            return result.Models.Select(InvitationMapper.ToDto);
        }

        public async Task<InvitationResponseDto> Create(CreateInvitationDto dto)
        {
            var model = InvitationMapper.ToModel(dto);
            var result = await _supabase.From<Invitation>().Insert(model);
            return InvitationMapper.ToDto(result.Models.First());
        }

        public async Task<InvitationResponseDto> GetInvitationByIdAsync(int id)
        {
            var result = await _supabase.From<Invitation>().Where(i => i.Id == id).Get();

            var model = result.Models.FirstOrDefault();

            if(model == null)
            {
                return null;
            }

            return InvitationMapper.ToDto(model);
        }

        public async Task<IEnumerable<InvitationResponseDto>> GetInvitationsByEventIdAsync(Guid eventId)
        {
            var result = await _supabase.From<Invitation>().Where(i => i.EventId == eventId).Get();
            return result.Models.Select(InvitationMapper.ToDto);
        }
    }
}