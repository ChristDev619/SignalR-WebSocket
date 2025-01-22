using Microsoft.AspNetCore.Mvc;
using SignalR_WebSocket_MSSQL.Models;

namespace SignalR_WebSocket_MSSQL.Controllers;

public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(ChatMessage chatMessage)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Save the message to the database (optional)
        // _dbContext.ChatMessages.Add(chatMessage);
        // _dbContext.SaveChanges();

        return Ok(new { message = "Message sent successfully" });
    }
}
