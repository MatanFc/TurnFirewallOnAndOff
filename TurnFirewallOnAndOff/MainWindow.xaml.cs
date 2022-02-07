using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TurnFirewallOnAndOff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _firewallStatus;

        public string FirewallStatus
        {
            get => _firewallStatus;
            set
            {
                _firewallStatus = value;
                OnPropertyChanged(nameof(FirewallStatus));
            }
        }
        public MainWindow()
        {
            DataContext = this;
            FirewallStatus = "";
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FirewallStatus == "On") return;
                string batchCommand = "netsh advfirewall set allprofiles state on";
                string command = $"/c {batchCommand}";
                Process.Start("CMD.exe", command);
                FirewallStatus = "On";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FirewallStatus == "Off") return;
                string batchCommand = "netsh advfirewall set allprofiles state off";
                string command = $"/c {batchCommand}";
                Process.Start("CMD.exe", command);
                FirewallStatus = "Off";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
