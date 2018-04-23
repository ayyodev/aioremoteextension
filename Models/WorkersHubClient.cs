using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Models.Annotations;

namespace Models
{
    public class WorkersHubClient : INotifyPropertyChanged
    {
        public string WorkerId { get; }
        public SubscribeMessage SubscribeMessage { get; }
        public string ConnectionId { get; }
        public List<WorkStatusUpdateMessage> Statuses { get; }

        public WorkStatusUpdateMessage LastStatus =>
            this.Statuses.OrderByDescending(s => s.DateReceived).FirstOrDefault();

        public WorkersHubClient(SubscribeMessage message, string workerId, string connectionId)
        {
            this.WorkerId = workerId;
            this.SubscribeMessage = message;
            this.ConnectionId = connectionId;
            this.Statuses = new List<WorkStatusUpdateMessage>();
        }

        public void AddStatus(WorkStatusUpdateMessage status)
        {
            this.Statuses.Add(status);
            this.OnPropertyChanged(nameof(LastStatus));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
