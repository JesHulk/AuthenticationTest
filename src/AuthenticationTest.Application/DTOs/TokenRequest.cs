namespace AuthenticationTest.Application.DTOs;

public record TokenRequest(string UserId, string SessionId, string ApiKey);