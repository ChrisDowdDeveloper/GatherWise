using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherWise.Dtos;
using GatherWise.Dtos.Auth;

namespace GatherWise.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResponseDto> SignUp(AuthRequestDto dto);
        Task<AuthResponseDto> SignIn(AuthRequestDto dto);
    }
}