using Prism.Regions;

using System.Windows.Controls;

namespace PrismOutlook.Core.Regions
{
    public class XamOutlookBarRegionAdapter : RegionAdapterBase<TabControl>
    {
        public XamOutlookBarRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {

        }

        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += ((x, y) =>
            {
                switch (y.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (TabItem i in y.NewItems)
                            {
                                regionTarget.Items.Add(i);

                                //The WPF XamOutlookBar does not automatically select the first group in it's collection.
                                //So we must manually select the group if it is the first one in the collection, but we don't
                                //want to excute this code every time a new group is added, only if the first group is the current group being added.

                                //! if (regionTarget.Items[0] == group)
                                //! {
                                //!     regionTarget.SelectedGroup = group;
                                //! }
                            }
                            break;
                        }
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (TabItem i in y.OldItems)
                            {
                                regionTarget.Items.Remove(i);
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
