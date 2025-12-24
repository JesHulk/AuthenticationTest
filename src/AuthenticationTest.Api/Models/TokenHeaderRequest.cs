using Microsoft.AspNetCore.Mvc;

namespace AuthenticationTest.Api.Models;

public record TokenHeaderRequest
{
    [FromHeader(Name = "user-id")]
    public string UserId { get; init; } = string.Empty;

    [FromHeader(Name = "session-id")]
    public string SessionId { get; init; } = string.Empty;
}