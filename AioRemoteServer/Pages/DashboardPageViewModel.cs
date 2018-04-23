using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AioRemoteServer.Annotations;
using AioRemoteServer.Hubs;
using Models;
using Xamarin.Forms;

namespace AioRemoteServer.Pages
{
    public class DashboardPageViewModel : INotifyPropertyChanged
    {
        private readonly WorkersSession workersSession;
        private readonly string userId;

        public ObservableCollection<WorkerViewModel> Workers { get; set; }

        private ICommand refreshWorkerCommand;

        public ICommand RefreshWorkerCommand => this.refreshWorkerCommand ??
                                                (this.refreshWorkerCommand =
                                                    new Command<string>(RefreshWorkerCommandExecute));

        private void RefreshWorkerCommandExecute(string id)
        {
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.GetStatus
            });
        }

        private ICommand startMiningCommand;
        public ICommand StartMiningCommand => this.startMiningCommand ??
                                              (this.startMiningCommand = new Command<string>(StartMiningCommandExecute));

        private void StartMiningCommandExecute(string id)
        {
            var worker = this.FindWorkerById(id);
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                Coin = worker.SelectedCoin,
                CommandType = WorkerCommandType.StartMining,
            });
        }

        private ICommand stopMiningCommand;

        public ICommand StopMiningCommand => this.stopMiningCommand ??
                                             (this.stopMiningCommand = new Command<string>(StopMiningCommandExecute));

        private void StopMiningCommandExecute(string id)
        {
            this.workersSession.RequestWorkerCommand(id, new WorkerCommandMessage
            {
                CommandType = WorkerCommandType.StopMining
            });
        }

        public bool AnyWorkersConnected => this.Workers.Any();


        //public DashboardPageViewModel()
        //{

        //}

        public DashboardPageViewModel(WorkersSession session, string userId)
        {
            this.userId = userId;
            this.workersSession = session;

            this.Workers = new ObservableCollection<WorkerViewModel>();

            foreach (var workersHubClient in this.workersSession.GetWorkersByUserId(this.userId))
            {
                this.RefreshWorkerCommandExecute(workersHubClient.WorkerId);
                this.Workers.Add(new WorkerViewModel(workersHubClient));
            }

            this.workersSession.WorkerConnected += args =>
            {
                if (args.UserId == this.userId)
                {
                    this.RefreshWorkerCommandExecute(args.Id);
                    this.Workers.Add(new WorkerViewModel(this.workersSession.FindWorkerById(args.Id)));
                    this.OnPropertyChanged(nameof(this.AnyWorkersConnected));
                }
            };

            this.workersSession.WorkerDisconnected += args =>
            {
                if (args.UserId == this.userId && this.Workers.Any())
                {
                    this.Workers.Remove(this.FindWorkerById(args.Id));
                    this.OnPropertyChanged(nameof(this.AnyWorkersConnected));
                }
            };
        }

        private WorkerViewModel FindWorkerById(string Id)
        {
            return this.Workers.FirstOrDefault(w => w.Id == Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
