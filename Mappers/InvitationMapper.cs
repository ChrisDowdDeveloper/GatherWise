using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Models;

namespace GatherWise.Mappers
{
    public class InvitationMapper
    {
        public static InvitationResponseDto ToDto(Invitation model)
        {
            return new InvitationResponseDto
            {
                Id = model.Id,
                Email = model.Email,
                Status = model.Status,
                SentAt = model.SentAt
            };
        }

        public static Invitation ToModel(CreateInvitationDto dto)
        {
            return new Invitation
            {
                EventId = dto.EventId,
                Email = dto.Email,
                Status = "pending",
                SentAt = DateTime.UtcNow
            };
        }
    }
}