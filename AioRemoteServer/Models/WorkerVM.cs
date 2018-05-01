using DotNetify;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AioRemoteServer.Models
{
    public class WorkerVM : ObservableObject
    {
        private readonly WorkersHubClient client;

        public string Id => this.client.WorkerId;

        public string Name { get => this.Get<string>(); set => this.Set(value); }
        public List<string> AvailableCoins { get => this.Get<List<string>>(); set => this.Set(value); }
        public string SelectedCoin { get => this.Get<string>(); set { this.Set(value); } }
        public string StatusText { get => this.Get<string>(); set => this.Set(value); }
        public string Gpus { get => this.Get<string>(); set => this.Set(value); }
        public string Temps { get => this.Get<string>(); set => this.Set(value); }
        public bool IsMining { get => this.Get<bool>(); set => this.Set(value); }

        public WorkerVM(WorkersHubClient client)
        {
            this.client = client;
            this.Name = this.client.SubscribeMessage.WorkerName;
            this.client.PropertyChanged += this.UpdateWorkerVM;
        }

        private void UpdateWorkerVM(object sender, PropertyChangedEventArgs e)
        {
            if (this.client.LastStatus != null)
            {
                this.Name = this.client.SubscribeMessage.WorkerName;
                this.AvailableCoins = this.client.LastStatus.AvailableCoins;
                this.SelectedCoin = this.client.LastStatus.SelectedCoin;
                this.StatusText = this.client.LastStatus.StatusMessage;
                this.Gpus = this.client.LastStatus.GPUs != null ? string.Join(";", this.client.LastStatus.GPUs) : string.Empty;
                this.Temps = this.client.LastStatus.Temps != null ? string.Join(";", this.client.LastStatus.Temps) : string.Empty;
                this.IsMining = this.client.LastStatus.IsMining;
            }
        }
    }
}
