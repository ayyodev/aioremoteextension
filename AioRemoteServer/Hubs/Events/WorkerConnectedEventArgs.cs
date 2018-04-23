using System;

namespace AioRemoteServer.Hubs.Events
{
    public delegate void WorkerConnectedEvent(WorkerConnectedEventArgs e);
    public class WorkerConnectedEventArgs : EventArgs
    {
        public string Id { get; }
        public string UserId { get; }

        public WorkerConnectedEventArgs(string id, string userId)
        {
            this.Id = id;
            this.UserId = userId;
        }
    }
}
