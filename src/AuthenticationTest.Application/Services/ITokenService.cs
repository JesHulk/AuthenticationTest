namespace AuthenticationTest.Application.Services;

public interface ITokenService
{
    /// <summary>
    /// Genera un token basado en la solicitud proporcionada.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Devuelve un objeto TokenResponse que contiene el token generado.</returns>
    TokenResponse? GenerateToken(TokenRequest request);

    /// <summary>
    /// Determina si la clave API proporcionada es válida.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <returns>Devuelve true si la clave API es válida, de lo contrario false.</returns>
    bool ValidateApiKey(string apiKey);
}