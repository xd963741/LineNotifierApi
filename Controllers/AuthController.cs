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

    

    [HttpGet("Test")]
    public async Task<IActionResult> Test([FromBody] LoginRequest req)
    {
        return Ok(new { success = true, msg = "hello" });
    }
}
