﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using AioRemoteExtension.Annotations;
using AIOminer;
using AIORClient;
using GalaSoft.MvvmLight.Command;
using Models;
using Xml2CSharp;

namespace AioRemoteExtension.Views
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AioRemoteClient aioClient;
        private readonly MyMiner aioMiner;

        private string currentCoinMining;

        public string CurrentCoinMining
        {
            get => this.currentCoinMining;
            set { this.currentCoinMining = value; OnPropertyChanged(); }
        }

        private string userName;

        public string UserName
        {
            get => userName;
            set { userName = value; OnPropertyChanged(); }
        }

        private string workerName;

        public string WorkerName
        {
            get => workerName;
            set { workerName = value; OnPropertyChanged(); }
        }

        private string errorText;

        public string ErrorText
        {
            get => errorText;
            set { errorText = value; OnPropertyChanged(); }
        }

        private bool isConnected;

        public bool IsConnected
        {
            get => isConnected;
            set { isConnected = value; OnPropertyChanged(); }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get => isLoading;
            set { isLoading = value; OnPropertyChanged(); }
        }


        private string statusText;

        public string StatusText
        {
            get => statusText;
            set { statusText = value; OnPropertyChanged(); }
        }

        private ICommand connectCommand;

        public ICommand ConnectCommand => connectCommand ?? (connectCommand = new RelayCommand(ConnectCommandExecute));

        public string DashboardUrl =>
            ConfigurationManager.AppSettings["ServerUrl"].Replace("WorkersHub", "Home/Dashboard");

        public LoginViewModel(MyMiner aioMiner)
        {
            this.aioMiner = aioMiner;
            this.aioClient = new AioRemoteClient(ConfigurationManager.AppSettings["ServerUrl"]);
            this.aioClient.WorkerCommandRequested += this.ExecuteWorkerCommand;
            this.aioClient.WorkerDisconnected += args =>
            {
                Thread.Sleep(15000);
                this.aioClient.Connect(this.WorkerName, this.UserName);
            };
        }

        private async void ConnectCommandExecute()
        {
            IsLoading = true;
            try
            {
                await this.aioClient.Connect(WorkerName, UserName);
                this.HookAio();
                this.IsConnected = true;
                this.StatusText = "Connected to server. Go to the dashboard.";
            }
            catch (Exception ex)
            {
                IsConnected = false;
                ErrorText = $"Error: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ExecuteWorkerCommand(WorkerCommandRequestedEventArgs e)
        {
            switch (e.WorkerCommandMessage.CommandType)
            {
                case WorkerCommandType.GetStatus:
                    this.SendStatusUpdate();
                    break;
                case WorkerCommandType.StartMining:
                    this.StartMining(e.WorkerCommandMessage.Coin);
                    this.SendStatusUpdate($"Started mining {e.WorkerCommandMessage.Coin}");
                    break;
                case WorkerCommandType.StopMining:
                    this.StopMining();
                    this.SendStatusUpdate("Clearing memory...");
                    Thread.Sleep(5500);
                    this.SendStatusUpdate("Stopped");
                    break;
            }
        }

        private async void SendStatusUpdate(string messageText = null)
        {
            // fix other thread error for winforms
            var status = await this.GetStatus();
            status.StatusMessage = messageText;
            await this.aioClient.SendStatusUpdate(status);
        }

        private async Task<WorkStatusUpdateMessage> GetStatus()
        {
            var message = new WorkStatusUpdateMessage();

            // fix other thread error for winforms
            this.aioMiner.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
           {

               var controls = this.GetAioControls();

               if (controls.avaialableCoinsComboBox != null)
               {
                   message.AvailableCoins = controls.avaialableCoinsComboBox.Items.Cast<string>().ToList();
                   message.SelectedCoin = controls.avaialableCoinsComboBox.SelectedItem as string;
               }

               message.IsMining = controls.startButton == null;

           });

            var nvidiaSmi = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "nvidia-smi.exe",
                    Arguments = "-q -x",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            await Task.Run(async () =>
            {
                try
                {
                    nvidiaSmi.Start();
                    var responseXml = await nvidiaSmi.StandardOutput.ReadToEndAsync();
                    nvidiaSmi.WaitForExit();
                    var doc = XDocument.Parse(responseXml);
                    var result = from s in doc.Descendants()
                                 select new Nvidia_smi_log();

                    var nvidiaSmiLogs = result.ToList();

                    message.GPUs = nvidiaSmiLogs.FirstOrDefault()?.Gpu.Select(g => g.Product_name).ToList();
                    message.Temps = nvidiaSmiLogs.FirstOrDefault()?.Gpu.Select(g => g.Temperature.Gpu_temp).ToList();
                }
                catch
                {
                    // ignored
                }
            });


            return message;
        }

        private (System.Windows.Forms.Label currentCoinMiningLabel,
            System.Windows.Forms.ComboBox avaialableCoinsComboBox,
            System.Windows.Forms.Button startButton,
            System.Windows.Forms.Button stopButton) GetAioControls()
        {
            System.Windows.Forms.Label miningLabel = null;
            if (this.aioMiner.Controls.Find("Label13", true).FirstOrDefault()
                is System.Windows.Forms.Label currentCoinLabel)
                miningLabel = currentCoinLabel;

            System.Windows.Forms.ComboBox tempComboBox = null;
            if (this.aioMiner.Controls.Find("ComboBox1", true).FirstOrDefault()
                is System.Windows.Forms.ComboBox coinsBox)
                tempComboBox = coinsBox;

            System.Windows.Forms.Button tempstartButton = null;
            if (this.aioMiner.Controls.Find("Button1", false).FirstOrDefault()
                is System.Windows.Forms.Button startButton)
                tempstartButton = startButton;

            System.Windows.Forms.Button tempStopButton = null;
            if (this.aioMiner.Controls.Find("Button2", false).FirstOrDefault()
                is System.Windows.Forms.Button stopButton)
                tempStopButton = stopButton;

            return (miningLabel, tempComboBox, tempstartButton, tempStopButton);
        }
        private void HookAio()
        {
            var controls = this.GetAioControls();

            controls.currentCoinMiningLabel.TextChanged += (sender, args) =>
                { this.CurrentCoinMining = args.ToString(); this.SendStatusUpdate(); };
            controls.avaialableCoinsComboBox.SelectedIndexChanged += (sender, args) => { this.SendStatusUpdate(); };
            controls.startButton.TextChanged += (sender, args) => { this.SendStatusUpdate(); };
        }

        private void StartMining(string coin)
        {
            // fix other thread error for winforms
            this.aioMiner.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
           {
               var controls = this.GetAioControls();

               if (controls.startButton != null)
               {
                   controls.avaialableCoinsComboBox.SelectedItem = coin;
                   controls.startButton.PerformClick();
               }
           });
        }

        private void StopMining()
        {
            var controls = this.GetAioControls();

            controls.stopButton?.PerformClick();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
