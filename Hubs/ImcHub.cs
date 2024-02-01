using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class ImcHub : Hub
    {

        public async Task EnviarImc(float imc)
        {
            await Clients.All.SendAsync("ReceiveImc", imc);
        }
    }
}
