using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Repositories;

namespace GatherWise.Interfaces
{
    public interface IInvitationRepository
    {
        Task<IEnumerable<InvitationResponseDto>> GetAll();
        Task<InvitationResponseDto> Create(CreateInvitationDto dto);
        Task<InvitationResponseDto> GetInvitationByIdAsync(int id);
        Task<IEnumerable<InvitationResponseDto>> GetInvitationsByEventIdAsync(Guid eventId);
    }
}