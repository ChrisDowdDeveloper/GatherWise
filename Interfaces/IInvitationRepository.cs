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
    }
}