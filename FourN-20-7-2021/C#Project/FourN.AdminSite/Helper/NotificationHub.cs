using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace FourN.AdminSite.Helper
{
    public class NotificationHub : Hub
    {
        public async Task SendNotify( string articleHeading, string articleContent)
        {
            await Clients.All.SendAsync("sendToUser", articleHeading, articleContent);
        }
    }
}
