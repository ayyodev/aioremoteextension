using DotNetify;
using Models;

namespace AioRemoteServer.Models
{
    public class WorkerVM : BaseVM
    {
        public string Name
        {
            get => this.Get<string>();
            set => this.Set(value);
        }

        public WorkerVM(WorkersHubClient client)
        {
            this.Name = client.SubscribeMessage.WorkerName;
        }
    }
}
