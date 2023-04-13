namespace Home.Api.Contracts.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public int CurrentVolts { get; set; }
        public bool GasUsage { get; set; }
        public string Location { get; set; } = null!;
    }
}
