using GeeksControl.Shared.DTO;

namespace GeeksControl.Shared.Device;

public static class DeviceStatusCollector
{
    public static DeviceStatus Collect()
    {
        return new DeviceStatus
        {
            DeviceId = Environment.MachineName,
            Uptime = TimeSpan.FromMilliseconds(Environment.TickCount64),
            CpuCores = Environment.ProcessorCount,
            Timestamp = DateTime.UtcNow
        };
    }
}