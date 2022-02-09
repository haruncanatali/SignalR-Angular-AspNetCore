using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SecimAnaliz.API.Hubs
{
    public class OyHub:Hub
    {
        public async Task SendMessageAsync()
        {
            await Clients.All.SendAsync("receiveMessage", "Merhaba");
        }
    }
}
