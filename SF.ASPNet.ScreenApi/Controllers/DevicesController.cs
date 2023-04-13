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
        private readonly IHostEnvironment _env;

        public DevicesController(ILogger<Controllers.WeatherForecastController> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
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
            var staticPath = Path.Combine(_env.ContentRootPath, "Static");
            var filePath = Directory.GetFiles(staticPath)
                .FirstOrDefault(f => f.Split("\\")
                    .Last()
                    .Split('.')[0] == manufacturer);

            if (string.IsNullOrEmpty(filePath))
                return StatusCode(404, $"Инструкции дял производителя '{manufacturer}' не найдено на сервере.");

            string fileType = "application/pdf";
            string fileName = $"{manufacturer}.pdf";

            return PhysicalFile(filePath, fileType, fileName);
        }
    }
}
