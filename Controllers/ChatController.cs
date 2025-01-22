using Microsoft.AspNetCore.Mvc;
using SignalR_WebSocket_MSSQL.Models;

namespace SignalR_WebSocket_MSSQL.Controllers;

public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
 
}
