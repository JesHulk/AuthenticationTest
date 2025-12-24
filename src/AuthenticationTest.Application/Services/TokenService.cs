namespace AuthenticationTest.Application.Services;

public class TokenService(IOptions<JwtSettings> jwtSettings) : ITokenService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public TokenResponse? GenerateToken(TokenRequest request)
    {
        if (!ValidateApiKey(request.ApiKey))
        {
            return null;
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("user-id"   , request.UserId),
            new Claim("session-id", request.SessionId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, 
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), 
                ClaimValueTypes.Integer64)
        };

        var token = new JwtSecurityToken(
            issuer            : _jwtSettings.Issuer,
            audience          : _jwtSettings.Audience,
            claims            : claims,
            expires           : DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenResponse(Token    : tokenString,
                                 Type     : "Bearer",
                                 ExpiresIn: _jwtSettings.ExpirationMinutes * 60
        );
    }

    public bool ValidateApiKey(string apiKey)
    {
        return !string.IsNullOrEmpty(apiKey) && 
               string.Equals(apiKey, _jwtSettings.ApiKey, StringComparison.Ordinal);
    }
}