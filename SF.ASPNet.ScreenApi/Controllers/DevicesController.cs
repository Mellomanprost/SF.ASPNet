using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SF.ASPNet.ScreenApi.Configuration;

namespace SF.ASPNet.ScreenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly ILogger<Controllers.WeatherForecastController> _logger;

        public DevicesController(ILogger<Controllers.WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Поиск и загрузка инструкции по использованию устройства
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        [Route("{manufacturer}")]
        public IActionResult GetManual([FromRoute] string manufacturer)
        {
            return StatusCode(200);
        }
    }
}
