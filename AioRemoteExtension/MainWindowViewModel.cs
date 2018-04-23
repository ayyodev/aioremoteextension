using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AioRemoteExtension.Annotations;
using AIOminer;
using GalaSoft.MvvmLight.CommandWpf;

namespace AioRemoteExtension
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MyMiner aioMiner;

        private string currentCoinMining;

        public string CurrentCoinMining
        {
            get => this.currentCoinMining;
            set { this.currentCoinMining = value; OnPropertyChanged(); }
        }

        private ICommand testCommand;
        public ICommand TestCommand => this.testCommand ?? (this.testCommand = new RelayCommand(TestCommandExecute));

        private void TestCommandExecute()
        {
            this.GetConfiguredCoins();
            this.HookAio();
        }

        public MainWindowViewModel(MyMiner aioMiner)
        {
            this.aioMiner = aioMiner;
            this.HookAio();
        }

        private void HookAio()
        {
            if (this.aioMiner.Controls.Find("Label13", true).FirstOrDefault() is System.Windows.Forms.Label currentCoinLabel)
                currentCoinLabel.TextChanged += (sender, args) => { this.CurrentCoinMining = args.ToString(); };

        }

        private IEnumerable<string> GetConfiguredCoins()
        {
            if (this.aioMiner.Controls.Find("ComboBox1", true).FirstOrDefault() is System.Windows.Forms.ComboBox
                coinsBox)
            {
                return coinsBox.Items.Cast<string>();
            }

            return null;
        }

        private void StartMining()
        {
            if (this.aioMiner.Controls.Find("Button1", false).FirstOrDefault() is System.Windows.Forms.Button startButton)
            {
                startButton.PerformClick();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
