using Microsoft.EntityFrameworkCore;
using LoginLoggerApi.Models;

namespace LoginLoggerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<LoginLog> LoginLogs { get; set; }
}
