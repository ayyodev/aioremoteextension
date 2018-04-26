using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AioRemoteServer.Annotations;
using Models;

namespace AioRemoteServer.Pages
{
    public class WorkerViewModel : INotifyPropertyChanged
    {
        private readonly WorkersHubClient client;
        public string Id => this.client.WorkerId;
        public string Name => this.client.SubscribeMessage.WorkerName;
        public string StatusMessage => this.client.LastStatus?.StatusMessage;
        public bool IsMining => this.client.LastStatus?.IsMining != null;
        public string GPUs => this.client.LastStatus?.GPUs != null ? string.Join(";", this.client.LastStatus.GPUs) : string.Empty;
        public string Temps => this.client.LastStatus?.Temps != null ? string.Join(";", this.client.LastStatus.Temps) : string.Empty;

        private string selectedCoin;

        public string SelectedCoin
        {
            get => this.selectedCoin; set { this.selectedCoin = value; OnPropertyChanged(); }
        }

        public List<string> AvailableCoins => this.client.LastStatus?.AvailableCoins;

        public WorkerViewModel(WorkersHubClient client)
        {
            this.client = client;
            this.client.PropertyChanged += (sender, args) =>
            {
                if (this.SelectedCoin == null && this.client.LastStatus.AvailableCoins.Count > 0)
                    this.SelectedCoin = this.client.LastStatus.AvailableCoins[0];
                this.OnPropertyChanged(nameof(AvailableCoins));
                this.OnPropertyChanged(nameof(GPUs));
                this.OnPropertyChanged(nameof(SelectedCoin));
                this.OnPropertyChanged(nameof(Temps));
                this.OnPropertyChanged(nameof(StatusMessage));
                this.OnPropertyChanged(nameof(IsMining));
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
