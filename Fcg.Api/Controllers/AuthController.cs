using Fcg.Api.DTOs.Auth;
using Fcg.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Fcg.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            Nome = request.Nome,
            Email = request.Email,
            UserName = request.Email,
            Perfil = Fcg.Domain.Enums.PerfilUsuario.Usuario
        };

        var result = await _userManager.CreateAsync(
            user,
            request.Senha);

        if (!result.Succeeded)
        {
            return BadRequest(new
            {
                Erros = result.Errors.Select(error => error.Description)
            });
        }

        var roleResult = await _userManager.AddToRoleAsync(
            user,
            "Usuario");

        if (!roleResult.Succeeded)
        {
            return BadRequest(new
            {
                Erros = roleResult.Errors.Select(error => error.Description)
            });
        }

        return Ok(new
        {
            Mensagem = "Usuário cadastrado com sucesso."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(
            request.Email);

        if (user is null)
        {
            return Unauthorized(new
            {
                Mensagem = "E-mail ou senha inválidos."
            });
        }

        var passwordValid = await _userManager.CheckPasswordAsync(
            user,
            request.Senha);

        if (!passwordValid)
        {
            return Unauthorized(new
            {
                Mensagem = "E-mail ou senha inválidos."
            });
        }

        var roles = await _userManager.GetRolesAsync(user);

        var token = _jwtService.GenerateToken(
            user,
            roles);

        return Ok(new
        {
            Token = token
        });
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("perfil")]
    public async Task<IActionResult> Perfil()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(new
        {
            user.Id,
            user.Nome,
            user.Email,
            user.Perfil
        });
    }
}