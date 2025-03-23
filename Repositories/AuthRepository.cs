using Supabase;
using GatherWise.Interfaces;
using GatherWise.Dtos;
using GatherWise.Dtos.Auth;

public class AuthRepository : IAuthRepository
{
    private readonly Client _supabase;

    public AuthRepository(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<AuthResponseDto> SignIn(AuthRequestDto dto)
    {
        var session = await _supabase.Auth.SignIn(dto.Email, dto.Password);

        return new AuthResponseDto
        {
            UserId = session.User?.Id,
            Email = session.User?.Email,
            AccessToken = session.AccessToken
        };
    }

    public async Task<AuthResponseDto> SignUp(AuthRequestDto dto)
    {
        var session = await _supabase.Auth.SignUp(dto.Email, dto.Password);

        return new AuthResponseDto
        {
            UserId = session.User?.Id,
            Email = session.User?.Email,
            AccessToken = session.AccessToken
        };
    }

}
