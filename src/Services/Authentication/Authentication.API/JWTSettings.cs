namespace NekoNetGPT.API;

public class JwtSettings
{
    public string? SecretKey { get; set; }
    public int ExpireDays { get; set; }
}