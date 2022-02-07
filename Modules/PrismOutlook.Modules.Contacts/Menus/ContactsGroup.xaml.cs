using PrismOutlook.Core;

using System.Windows.Controls;

namespace PrismOutlook.Modules.Contacts.Menus
{
    /// <summary>
    /// Interaction logic for ContactsGroup.xaml
    /// </summary>
    public partial class ContactsGroup : TabItem, IOutlookBarGroup
    {
        public ContactsGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath => "ViewA";
    }
}
