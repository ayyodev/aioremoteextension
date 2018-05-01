using System.Windows;
using System.Windows.Interop;
using AioRemoteExtension.Views;
using AIOminer;

namespace AioRemoteExtension
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var aioMiner = new MyMiner();
            //var wih = new WindowInteropHelper(this) {Owner = aioMiner.Handle};
            aioMiner.Show();
            //aioMiner.Hide();
            this.loginWiew.DataContext = new LoginViewModel(aioMiner);
        }
    }
}
