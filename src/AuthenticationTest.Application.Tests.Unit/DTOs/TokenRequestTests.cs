using AuthenticationTest.Application.DTOs;

namespace AuthenticationTest.Application.Tests.Unit.DTOs;

public class TokenRequestTests
{
    #region Construction Tests

    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        const string userId    = "user123";
        const string sessionId = "session456";
        const string apiKey    = "api-key-789";

        // Act
        var tokenRequest = new TokenRequest(userId, sessionId, apiKey);

        // Assert
        Assert.NotNull(tokenRequest);
        Assert.Equal(userId, tokenRequest.UserId);
        Assert.Equal(sessionId, tokenRequest.SessionId);
        Assert.Equal(apiKey, tokenRequest.ApiKey);
    }

    [Fact]
    public void Constructor_WithEmptyStrings_ShouldCreateInstance()
    {
        // Arrange & Act
        var tokenRequest = new TokenRequest(string.Empty, string.Empty, string.Empty);

        // Assert
        Assert.NotNull(tokenRequest);
        Assert.Equal(string.Empty, tokenRequest.UserId);
        Assert.Equal(string.Empty, tokenRequest.SessionId);
        Assert.Equal(string.Empty, tokenRequest.ApiKey);
    }

    [Fact]
    public void Constructor_WithNullValues_ShouldCreateInstance()
    {
        // Arrange & Act
        var tokenRequest = new TokenRequest(null!, null!, null!);

        // Assert
        Assert.NotNull(tokenRequest);
        Assert.Null(tokenRequest.UserId);
        Assert.Null(tokenRequest.SessionId);
        Assert.Null(tokenRequest.ApiKey);
    }

    #endregion

}
