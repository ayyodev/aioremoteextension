using AioRemoteServer.Hubs;
using DotNetify;
using DotNetify.Security;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AioRemoteServer.Models
{
    public class DashboardVM : BaseVM
    {
        private readonly string userName;
        private readonly WorkersSession workersSession;

        public ObservableCollection<WorkerVM> Workers { get; }

        public ICommand RefreshWorkerCommand => new Command<string>(RefreshWorkerCommandExecute);

        public DashboardVM(WorkersSession workerSession, IPrincipalAccessor principalAccessor)
        {
            this.workersSession = workerSession;
            this.userName = principalAccessor.Principal.Identity.Name;
            this.Workers = new ObservableCollection<WorkerVM>();


            // Add the user's workers
            foreach (var workersHubClient in this.workersSession.GetWorkersByUserId(this.userName))
            {
                this.RefreshWorkerCommandExecute(workersHubClient.WorkerId);
                this.Workers.Add(new WorkerVM(workersHubClient));
            }

            // Test worker
            this.Workers.Add(new WorkerVM(new WorkersHubClient(new SubscribeMessage { WorkerName = "testworker" }, "test", "test")));

            this.workersSession.WorkerConnected += args =>
            {
                if (args.UserId == this.userName)
                {
                    this.RefreshWorkerCommandExecute(args.Id);
                    this.Workers.Add(new WorkerVM(this.workersSession.FindWorkerById(args.Id)));
                }
            };
        }
        private void RefreshWorkerCommandExecute(string id)
        {
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.GetStatus
            });
        }
    }
}
