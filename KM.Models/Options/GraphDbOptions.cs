namespace KM.Models.Options;

public class GraphDbOptions
{
    public string BaseUrl { get; set; } = default!;
    public string Repository { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}