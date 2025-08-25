using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Application.DTOs;
using ShoppingSystem.Application.Interfaces;
using ShoppingSystem.Domain.Shared.Enums;
namespace ShoppingSystem.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }






    [HttpPost]
    [AllowAnonymous]
    [Tags("Users")]
    [EndpointSummary("Register a New User")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerDto)
    {
        try
        {
            var newUser = await _userService.AddUserAsync(registerDto);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser?.Id }, newUser);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }







    // Admin Requests

    [HttpGet("admin")]
    [Tags("Admin")]
    [EndpointSummary("Get All Users")]
    [Authorize(Roles = RoleTypeConstants.Admin)]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpDelete("admin")]
    [Tags("Admin")]
    [EndpointSummary("Clear Users Database")]
    [Authorize(Roles = RoleTypeConstants.Admin)]
    public async Task<IActionResult> ClearAllUsers()
    {
        await _userService.ClearAllAsync();
        return NoContent();
    }

    [HttpDelete("admin/{id}")]
    [Tags("Admin")]
    [EndpointSummary("Delete any User by Admin")]
    [Authorize(Roles = RoleTypeConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUserByAdmin(int id)
    {
        var success = await _userService.DeleteUserAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("admin/{id}")]
    [Tags("Admin")]
    [EndpointSummary("Edit any User by Admin")]
    [Authorize(Roles = RoleTypeConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditUserByAdmin(int id, [FromBody] EditByAdminDto updateDto)
    {
        var success = await _userService.EditUserByAdminAsync(id, updateDto);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }





    // User Requests

    [HttpPut("me")]
    [Tags("Users")]
    [EndpointSummary("Edit Infromation of Currently Logged in User")]
    [Authorize(Roles = RoleTypeConstants.User)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditCurrentUser([FromBody] EditUserDto updateDto)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdString, out var currUserId))
        {
            return Unauthorized("Invalid token.");
        }

        await _userService.EditUserAsync(currUserId, updateDto);

        return NoContent();
    }

    [HttpPut("me/password")]
    [Tags("Users")]
    [EndpointSummary("Edit Password of Currently Logged in User")]
    [Authorize(Roles = RoleTypeConstants.User)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditCurretnUserPassword([FromBody] EditPasswordDto updateDto)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdString, out var currUserId))
        {
            return Unauthorized("Invalid token.");
        }

        await _userService.EditPasswordAsync(currUserId, updateDto);

        return NoContent();
    }

    [HttpGet("{id}")]
    [Tags("Users")]
    [EndpointSummary("Get Information of any User by Id")]
    [Authorize(Roles = RoleTypeConstants.User)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete("me")]
    [Tags("Users")]
    [EndpointSummary("Delete Currently Logged in User")]
    [Authorize(Roles = RoleTypeConstants.User)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCurrentUser()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdString, out var currUserId))
        {
            return Unauthorized("Invalid token.");
        }
        
        var success = await _userService.DeleteUserAsync(currUserId);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
