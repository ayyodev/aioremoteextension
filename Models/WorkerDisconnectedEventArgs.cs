using System;

namespace Models
{
    public delegate void WorkerDisconnectedEvent(WorkerDisconnectedEventArgs e);
    public class WorkerDisconnectedEventArgs : EventArgs
    {
        public string Id { get; }
        public string UserId { get; }

        public WorkerDisconnectedEventArgs(string id, string userId)
        {
            this.Id = id;
            this.UserId = userId;
        }
    }
}
