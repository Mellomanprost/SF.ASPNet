using System.ComponentModel.DataAnnotations;

namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        [Required] // Указываем все параметры как обязательные
        public string Name { get; set; } = null!;
        [Required]
        public string Manufacturer { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public string SerialNumber { get; set; } = null!;
        [Required]
        public int CurrentVolts { get; set; }
        [Required]
        public bool GasUsage { get; set; }
        [Required]
        public string Location { get; set; } = null!;
    }
}
