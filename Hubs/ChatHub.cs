using Microsoft.AspNetCore.SignalR;
using SignalR_WebSocket_MSSQL.Models;
using SignalRChatApp.Data;

namespace SignalRChatApp.Hubs;

public class ChatHub : Hub
{
    private readonly AppDbContext _dbContext;

    public ChatHub(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SendMessage(string user, string message)
    {
        var chatMessage = new ChatMessage
        {
            User = user,
            Message = message,
            Timestamp = DateTime.Now
        };

        _dbContext.ChatMessages.Add(chatMessage);
        await _dbContext.SaveChangesAsync();

        // Broadcast to all connected clients
        await Clients.All.SendAsync("ReceiveMessage", user, message, chatMessage.Timestamp);
    }
}
