using Microsoft.EntityFrameworkCore;
using SignalRChatApp.Data;
using SignalRChatApp.Hubs;
  
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();

var app = builder.Build();

// Configure middleware
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chathub");

app.Run();
