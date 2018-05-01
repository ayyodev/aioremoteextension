using AioRemoteServer.Hubs;
using DotNetify;
using DotNetify.Security;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AioRemoteServer.Models
{
    public class DashboardVM : BaseVM
    {
        private readonly string userName;
        private readonly WorkersSession workersSession;

        public List<WorkerVM> Workers { get; }

        private ICommand refreshWorkerCommand;
        public ICommand RefreshWorkerCommand => this.refreshWorkerCommand ?? 
            (this.refreshWorkerCommand = new Command<string>(RefreshWorkerCommandExecute));

        private ICommand startMiningCommand;
        public ICommand StartMiningCommand => this.startMiningCommand ??
            (this.startMiningCommand = new Command<string>(StartMiningCommandExecute));

        private ICommand stopMiningCommand;
        public ICommand StopMiningCommand => this.stopMiningCommand ??
            (this.stopMiningCommand = new Command<string>(StopMiningCommandExecute));

        public bool AnyWorkersConnected => this.Workers.Count > 0;

        public DashboardVM(WorkersSession workerSession, IPrincipalAccessor principalAccessor)
        {
            this.workersSession = workerSession;
            this.userName = principalAccessor.Principal.Identity.Name;
            this.Workers = new List<WorkerVM>();


            // Add the user's workers
            this.workersSession.GetWorkersByUserId(this.userName)
                .ToList()
                .ForEach(w => this.AddWorker(this.userName, w.WorkerId));

            this.workersSession.WorkerConnected += args => this.AddWorker(args.UserId, args.Id);

            this.workersSession.WorkerDisconnected += args => this.RemoveWorker(args.UserId, args.Id);
        }

        private void AddWorker(string userName, string id)
        {
            if (userName != this.userName) return;

            var worker = FindWorkerById(id);
            if (worker != null) return;

            worker = new WorkerVM(this.workersSession.FindWorkerById(id));
            worker.PropertyChanged += (sender, e) => this.UpdateWorkerVM(worker.Id);

            this.Workers.Add(worker);
            this.Changed(() => this.AnyWorkersConnected);
            this.AddList(() => this.Workers, worker);
            this.RefreshWorkerCommandExecute(id);
        }

        private void RemoveWorker(string userName, string id)
        {
            var worker = this.FindWorkerById(id);

            if (userName == this.userName && worker != null)
            {
                this.Workers.Remove(worker);
                this.Changed(() => this.AnyWorkersConnected);
                this.RemoveList(() => this.Workers, worker.Id);
                this.PushUpdates();
            }
        }

        private WorkerVM FindWorkerById(string Id)
        {
            return this.Workers.FirstOrDefault(w => w.Id == Id);
        }

        private void RefreshWorkerCommandExecute(string id)
        {
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.GetStatus,
                DateCreated = DateTime.Now
            });
            this.UpdateWorkerVM(id);
        }

        private void StartMiningCommandExecute(string id)
        {
            var worker = this.FindWorkerById(id);
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.StartMining,
                Coin = worker.SelectedCoin,
                DateCreated = DateTime.Now
            });
        }

        private void StopMiningCommandExecute(string id)
        {
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.StopMining,
                DateCreated = DateTime.Now
            });
        }

        private void UpdateWorkerVM(string id)
        {
            var worker = FindWorkerById(id);
            if (worker == null) return;

            this.UpdateList(() => this.Workers, worker);
            this.PushUpdates();
        }
    }
}
