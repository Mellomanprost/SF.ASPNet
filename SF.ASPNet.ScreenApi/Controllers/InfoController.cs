using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SF.ASPNet.ScreenApi.Configuration;
using SF.ASPNet.ScreenApi.Models;

namespace SF.ASPNet.ScreenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<Controllers.WeatherForecastController> _logger;
        private IOptions<ScreenApiOptions> _options;    

        public InfoController(ILogger<Controllers.WeatherForecastController> logger, IOptions<ScreenApiOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, $"Имя сервера: {_options.Value.ServerName}");
        }
    }
}
