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

        private void XamOutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            //! var group = ((TabControl)sender).SelectedGroup as IOutlookBarGroup;
            //! if (group != null)
            //! {
            //!     _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
            //! }
        }
    }
}
