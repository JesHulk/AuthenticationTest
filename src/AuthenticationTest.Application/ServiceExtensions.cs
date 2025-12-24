namespace AuthenticationTest.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                 IConfiguration     configuration)
    {
        // Configurar JwtSettings
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        // Registrar servicios
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}