namespace GeeksControl.Shared.DTO;

public class DeviceStatus
{
    public string DeviceId { get; set; }
    public TimeSpan Uptime { get; set; }
    public int CpuCores { get; set; }
    public DateTime Timestamp { get; set; }
}