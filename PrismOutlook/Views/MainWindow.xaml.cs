using Prism.Regions;
using PrismOutlook.Core;
using System.Windows;
using System.Windows.Controls;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApplicationCommands _applicationCommands;

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();
            _applicationCommands = applicationCommands;
        }

        private void OutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            if (((TabControl)sender).SelectedItem is IOutlookBarGroup tabitem)
            {
                _applicationCommands.NavigateCommand.Execute(tabitem.DefaultNavigationPath);
            }
        }
    }
}
