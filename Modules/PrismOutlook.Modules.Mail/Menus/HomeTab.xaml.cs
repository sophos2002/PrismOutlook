using PrismOutlook.Core;

using System.Windows.Controls;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// Interaction logic for HomeTab.xaml
    /// </summary>
    public partial class HomeTab : MenuItem, ISupportDataContext
    {
        public HomeTab()
        {
            InitializeComponent();
            //! SetResourceReference(StyleProperty, typeof(MenuItem));
        }
    }
}
