using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Application.DTOs;
using ShoppingSystem.Application.Services;
namespace ShoppingSystem.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [EndpointSummary("Authorize User")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        if (token == null)
        {
            return Unauthorized("Invalid authorization");
        }

        return Ok(token);
    }

}