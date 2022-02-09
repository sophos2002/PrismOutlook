using Prism.Regions;

using System.Diagnostics;
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
                Debug.WriteLine("OutlookBarRegionAdapter:" + e.Action.ToString());

                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (TabItem i in e.NewItems)
                            {
                                targetTabControl.Items.Add(i);
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
