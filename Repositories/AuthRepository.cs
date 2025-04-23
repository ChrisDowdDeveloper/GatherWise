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
            Name = session.User?.UserMetadata["full_name"]?.ToString(),
            AccessToken = session.AccessToken
        };
    }

    public async Task<AuthResponseDto> SignUp(AuthRequestDto dto)
    {
        var options = new Supabase.Gotrue.SignUpOptions
        {
            Data = new Dictionary<string, object>
            {
                { "full_name", dto.Name }
            }
        };

        var session = await _supabase.Auth.SignUp(dto.Email, dto.Password, options);

        return new AuthResponseDto
        {
            UserId = session.User?.Id,
            Email = session.User?.Email,
            Name = session.User?.UserMetadata["full_name"]?.ToString(),
            AccessToken = session.AccessToken
        };
    }


}
