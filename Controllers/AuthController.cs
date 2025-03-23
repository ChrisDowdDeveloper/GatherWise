using Microsoft.AspNetCore.Mvc;
using GatherWise.Interfaces;
using GatherWise.Dtos;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _auth;

    public AuthController(IAuthRepository auth)
    {
        _auth = auth;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] AuthRequestDto dto)
    {
        var result = await _auth.SignUp(dto);
        return Ok(result);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] AuthRequestDto dto)
    {
        var result = await _auth.SignIn(dto);
        return Ok(result);
    }
}
