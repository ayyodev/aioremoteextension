using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AioRemoteServer.Annotations;
using AioRemoteServer.Hubs.Events;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace AioRemoteServer.Hubs
{
    public class WorkersSession : INotifyPropertyChanged
    {
        private readonly List<WorkersHubClient> workers;
        private IHubContext<WorkersHub> workersHubContext;

        public WorkersSession()
        {
            this.workers = new List<WorkersHubClient>();
        }

        public void SetHubContext(IHubContext<WorkersHub> workersHubContext)
        {
            if (this.workersHubContext == null)
                this.workersHubContext = workersHubContext;
        }

        public void AddWorker(WorkersHubClient client)
        {
            this.workers.Add(client);
            this.WorkerConnected?
                .Invoke(new WorkerConnectedEventArgs(client.WorkerId, client.SubscribeMessage.UserId));
        }

        public void RemoveWorker(WorkersHubClient client)
        {
            this.workers.Remove(client);
            this.WorkerConnected?
                .Invoke(new WorkerConnectedEventArgs(client.WorkerId, client.SubscribeMessage.UserId));
        }

        public void RemoveWorker(string connectionId)
        {
            var worker = this.FindWorkerByConnectionId(connectionId);
            if (worker != null)
            {
                this.workers.Remove(worker);
                this.WorkerDisconnected?
                    .Invoke(new WorkerDisconnectedEventArgs(worker.WorkerId, worker.SubscribeMessage.UserId));
            }
        }

        public WorkersHubClient FindWorkerByConnectionId(string connectionId)
        {
            return this.workers.FirstOrDefault(w => w.ConnectionId == connectionId);
        }

        public WorkersHubClient FindWorkerById(string workerId)
        {
            return this.workers.FirstOrDefault(w => w.WorkerId == workerId);
        }

        public IEnumerable<WorkersHubClient> GetWorkersByUserId(string userId)
        {
            return this.workers.Where(w => w.SubscribeMessage.UserId == userId);
        }

        public void AddWorkerStatus(WorkStatusUpdateMessage status, string connectionId)
        {
            var worker = this.FindWorkerByConnectionId(connectionId);
            worker?.AddStatus(status);
        }

        public async void RequestWorkerCommand(string workerId, WorkerCommandMessage command)
        {
            var worker = this.FindWorkerById(workerId);
            if (worker != null)
                await this.workersHubContext.Clients.Client(worker.ConnectionId)
                    .SendAsync("CommandReceived", command);
        }


        public event PropertyChangedEventHandler PropertyChanged;



        public event WorkerConnectedEvent WorkerConnected;
        public event WorkerDisconnectedEvent WorkerDisconnected;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
