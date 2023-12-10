using Microsoft.AspNetCore.SignalR;
namespace AnswerSphere.Hubs
{
    public class AnswerHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("AnswerChange");
        }
    }
}