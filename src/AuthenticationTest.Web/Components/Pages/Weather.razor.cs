namespace AuthenticationTest.Web.Components.Pages;
public partial class Weather
{
    private WeatherForecast[]? forecasts;
    private string? errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            forecasts = await WeatherApi.GetWeatherAsync();
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            errorMessage = "No autorizado. Por favor, inicia sesión.";
        }
    }
}
