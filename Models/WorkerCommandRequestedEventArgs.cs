using System;

namespace Models
{
    public delegate void WorkerCommandRequestedEvent(WorkerCommandRequestedEventArgs e);
    public class WorkerCommandRequestedEventArgs : EventArgs
    {
        public WorkersHubClient WorkersHubClient { get; }
        public WorkerCommandMessage WorkerCommandMessage { get; }

        public WorkerCommandRequestedEventArgs(WorkersHubClient worker, WorkerCommandMessage message)
        {
            this.WorkersHubClient = worker;
            this.WorkerCommandMessage = message;
        }
    }
}
