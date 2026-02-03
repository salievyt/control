namespace GeeksControl.Shared.DTO;

public class DeviceStatus
{
    public string DeviceId { get; set; } = null!;
    public TimeSpan Uptime { get; set; }
    public int CpuCores { get; set; }
    public DateTime Timestamp { get; set; }
}