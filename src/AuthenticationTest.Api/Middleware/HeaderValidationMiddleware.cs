namespace AuthenticationTest.Api.Middleware;

public class HeaderValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HeaderValidationMiddleware> _logger;
    private static readonly string[] ExcludedPaths = ["/health", "/alive", "/auth/token"];

    public HeaderValidationMiddleware(RequestDelegate next, ILogger<HeaderValidationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLowerInvariant() ?? string.Empty;

        // Permitir acceso a endpoints excluidos
        if (ExcludedPaths.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
        {
            await _next(context);
            return;
        }

        var hasUserId = context.Request.Headers.TryGetValue("user-id", out var userId) 
                        && !string.IsNullOrWhiteSpace(userId);
        var hasSessionId = context.Request.Headers.TryGetValue("session-id", out var sessionId) 
                           && !string.IsNullOrWhiteSpace(sessionId);

        if (!hasUserId || !hasSessionId)
        {
            _logger.LogWarning(
                "Request rechazado: Faltan headers requeridos. Path: {Path}, user-id: {HasUserId}, session-id: {HasSessionId}", 
                path, hasUserId, hasSessionId);
            
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new 
            { 
                Error = "Headers requeridos: user-id y session-id" 
            });
            return;
        }

        await _next(context);
    }
}

public static class HeaderValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder builder)
        => builder.UseMiddleware<HeaderValidationMiddleware>();
}