using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace AioRemoteServer.Hubs
{
    public class WorkersHub : Hub
    {
        private readonly WorkersSession session;

        public WorkersHub(WorkersSession session)
        {
            this.session = session;
        }

        public override Task OnDisconnectedAsync(Exception ex)
        {
            this.session.RemoveWorker(this.Context.ConnectionId);
            return base.OnDisconnectedAsync(ex);
        }

        public void Subscribe(SubscribeMessage message)
        {
            message.DateReceived = DateTime.Now;
            var id = Guid.NewGuid();
            var client = new WorkersHubClient(message, id.ToString(), this.Context.ConnectionId);
            this.session.AddWorker(client);
        }

        public void AddWorkerStatus(WorkStatusUpdateMessage message)
        {
            this.session.AddWorkerStatus(message, this.Context.ConnectionId);
        }

        public async void CommandWorker(WorkerCommandMessage message, string connectionId)
        {
            await this.Clients.Client(connectionId).InvokeAsync("CommandReceived", message);
        }
    }
}
