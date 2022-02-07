using PrismOutlook.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismOutlook.Modules.Mail;
using Prism.Regions;
using PrismOutlook.Core.Regions;
using PrismOutlook.Modules.Contacts;
using PrismOutlook.Core;
using PrismOutlook.Core.Dialogs;
using Prism.Services.Dialogs;
using System.Windows.Controls;

namespace PrismOutlook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRegionDialogService, RegionDialogService>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

            //containerRegistry.RegisterDialogWindow<RibbonWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<XamOutlookBarRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(Menu), Container.Resolve<XamRibbonRegionAdapter>());
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            regionBehaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));
        }
    }
}
