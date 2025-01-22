using Microsoft.EntityFrameworkCore;
using SignalR_WebSocket_MSSQL.Models;

namespace SignalRChatApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ChatMessage> ChatMessages { get; set; }
}
