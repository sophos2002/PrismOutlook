using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.ViewModels;
using System.Linq;
using System.Windows.Controls;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : TabItem, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();

            _dataTree.Loaded += DataTree_Loaded;
        }

        private void DataTree_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _dataTree.Loaded -= DataTree_Loaded;

            var obj = _dataTree.ItemContainerGenerator.ContainerFromItem(_dataTree.Items[0]);
            var tvi = obj as TreeViewItem;
            if (tvi != null)
            {
                tvi.IsSelected = true;
            }
        }

        public string DefaultNavigationPath
        {
            get
            {
                if (_dataTree.SelectedItem is TreeViewItem selectedTVI)
                {
                    if (_dataTree.ItemContainerGenerator.ItemFromContainer(selectedTVI) is NavigationItem ni)
                        return ni.NavigationPath;
                }

                return $"MailList?{FolderParameters.FolderKey}={FolderParameters.Inbox}";
            }
        }
    }
}
