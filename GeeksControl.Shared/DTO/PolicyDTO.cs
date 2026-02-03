namespace GeeksControl.Shared.DTO;

public class PolicyDTO
{
    public bool Lock { get; set; }
    public string[] BlockedSites { get; set; } = Array.Empty<string>();
}