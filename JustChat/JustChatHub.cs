using Microsoft.AspNetCore.SignalR;

namespace JustChat;

public class JustChatHub : Hub
{
    public const string HubUrl = "/chat";

    public async Task Broadcast(string username, string message)
    {
        await Clients.All.SendAsync("Broadcast", username, message);
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} joined the chat.");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception e)
    {
        Console.WriteLine($"{Context.ConnectionId} left the chat. ({e?.Message})");
        await base.OnDisconnectedAsync(e);
    }
}