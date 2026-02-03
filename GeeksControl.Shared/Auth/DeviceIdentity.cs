namespace GeeksControl.Shared.Auth;

public class DeviceIdentity
{
    public string DeviceId { get; set; } = Environment.MachineName;

    public static DeviceIdentity LoadOrCreate()
    {
        return new DeviceIdentity();
    }
}