using Prism.Regions;

using System.Windows.Controls;

namespace PrismOutlook.Core.Regions
{
    public class OutlookBarRegionAdapter : RegionAdapterBase<TabControl>
    {
        public OutlookBarRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {

        }

        protected override void Adapt(IRegion region, TabControl targetTabControl)
        {
            region.Views.CollectionChanged += ((s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (TabItem i in e.NewItems)
                            {
                                targetTabControl.Items.Add(i);

                                //The WPF XamOutlookBar does not automatically select the first group in it's collection.
                                //So we must manually select the group if it is the first one in the collection, but we don't
                                //want to excute this code every time a new group is added, only if the first group is the current group being added.

                                if (targetTabControl.Items[0] == i)
                                {
                                    targetTabControl.SelectedItem = i;
                                }
                            }
                            break;
                        }
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (TabItem i in e.OldItems)
                            {
                                targetTabControl.Items.Remove(i);
                            }
                            break;
                        }
                }
            });
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
