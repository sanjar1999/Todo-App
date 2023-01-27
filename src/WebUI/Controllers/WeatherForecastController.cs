using Microsoft.AspNetCore.Mvc;
using Todo_App.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Todo_App.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
