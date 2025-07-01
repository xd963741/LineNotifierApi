namespace LoginLoggerApi.Models;

public class LoginLog
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; // 明文密碼
    public string ClientIp { get; set; } = string.Empty;
    public string ClientHost { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
