using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Models;

namespace AIORClient
{
    public class AioRemoteClient
    {
        private readonly string hubUrl;
        private HubConnection hubConnection;

        public AioRemoteClient(string hubUrl)
        {
            this.hubUrl = hubUrl;

        }

        public Task Connect(string workername, string username)
        {
            this.hubConnection = new HubConnectionBuilder()
                .WithUrl(this.hubUrl)
                .Build();
            this.hubConnection.On<WorkerCommandMessage>("CommandReceived", (commandMessage) =>
                this.WorkerCommandRequested?
                    .Invoke(new WorkerCommandRequestedEventArgs(null, commandMessage)));
            this.hubConnection.Closed += exception =>
            {
                this.WorkerDisconnected?.Invoke(new WorkerDisconnectedEventArgs(null, null));
            };

            return Task.Run(async () =>
            {
                await this.hubConnection.StartAsync();
                await this.hubConnection.InvokeAsync("Subscribe", new SubscribeMessage
                {
                    DateCreated = DateTime.Now,
                    UserId = username,
                    WorkerName = workername
                });
            });
        }

        public Task SendStatusUpdate(WorkStatusUpdateMessage message)
        {
            return this.hubConnection.InvokeAsync("AddWorkerStatus", message);
        }

        public event WorkerCommandRequestedEvent WorkerCommandRequested;
        public event WorkerDisconnectedEvent WorkerDisconnected;
    }
}
