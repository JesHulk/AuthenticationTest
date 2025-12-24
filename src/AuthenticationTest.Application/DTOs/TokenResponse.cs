namespace AuthenticationTest.Application.DTOs;

public record TokenResponse(string Token, string Type, int ExpiresIn);