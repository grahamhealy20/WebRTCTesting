using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace WebRTCTesting.Hubs
{
    // SignalR hub to broker webRTC connections
    [HubName("VideoHub")]
    public class VideoHub : Hub
    {
        // Hub of users to connections
        private static readonly ConcurrentDictionary<string, string> Users = new ConcurrentDictionary<string, string>();

        // override methods when a user connects
        public override Task OnConnected()
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            var user = Users.GetOrAdd(userName, connectionId);
            return base.OnConnected();
        }

        // override methods when a user disconnects
        public override Task OnDisconnected(bool stopCalled)
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            bool user = Users.TryGetValue(userName, out connectionId);

            if (user == true)
            {
                        Users.TryRemove(userName, out connectionId);
            }

            return base.OnDisconnected(stopCalled);
        }

        public void Hello()
        {
            Clients.All.hello();
        }

        //public void Send(string message) {
        //    Clients.All.sendMessage(message);
        //}

        public void Send(string message, string id) {
            Clients.All.onMessageReceived(message);
        }
    }
}