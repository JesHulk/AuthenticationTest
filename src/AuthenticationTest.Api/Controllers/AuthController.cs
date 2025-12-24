using AuthenticationTest.Api.Models;
using AuthenticationTest.Application.DTOs;
using AuthenticationTest.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationTest.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(ITokenService tokenService, ILogger<AuthController> logger) 
    : ControllerBase
{
    private readonly ITokenService           _tokenService = tokenService;
    private readonly ILogger<AuthController> _logger       = logger;

    /// <summary>
    /// Genera un token JWT si la API Key es válida
    /// </summary>
    [HttpPost("token")]
    [AllowAnonymous]
    public IActionResult GenerateToken([FromHeader(Name = "X-Api-Key")] string apiKey,
                                       [FromHeader]                     TokenHeaderRequest headers)
    {
        if (string.IsNullOrWhiteSpace(headers.UserId))
        {
            return BadRequest(new { Error = "Header user-id requerido" });
        }

        if (string.IsNullOrWhiteSpace(headers.SessionId))
        {
            return BadRequest(new { Error = "Header session-id requerido" });
        }

        var request = new TokenRequest(headers.UserId, headers.SessionId, apiKey);
        var response = _tokenService.GenerateToken(request);

        if (response is null)
        {
            _logger.LogWarning("Intento de generación de token con API Key inválida");
            return Unauthorized(new { Error = "API Key inválida" });
        }

        _logger.LogInformation("Token generado para user-id: {UserId}", headers.UserId);
        return Ok(response);
    }

    /// <summary>
    /// Valida que el token JWT sea correcto
    /// </summary>
    [HttpGet("validate")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        var userId = User.FindFirst("user-id")?.Value;
        var sessionId = User.FindFirst("session-id")?.Value;

        return Ok(new
        {
            Message = "Token válido",
            UserId = userId,
            SessionId = sessionId
        });
    }
}