namespace SF.ASPNet.ScreenApi.Configuration
{
    public class ScreenApiOptions
    {
        public long Capacity { get; set; }
        public string ServerName { get; set; } = null!;
        public StorageType StorageType { get; set; }
    }
}
