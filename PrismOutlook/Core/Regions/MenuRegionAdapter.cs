using Prism.Regions;
using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace PrismOutlook.Core.Regions
{
    public class MenuRegionAdapter : RegionAdapterBase<Menu>
    {
        public MenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Menu targetMenu)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (targetMenu == null) throw new ArgumentNullException(nameof(targetMenu));

            region.Views.CollectionChanged += (s, e) =>
            {
                Debug.WriteLine("MenuRegionAdapter:" + e.Action.ToString());

                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        AddViewToRegion(view, targetMenu);
                    }

                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        RemoveViewFromRegion(view, targetMenu);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        static void AddViewToRegion(object view, Menu menu)
        {
            var item = view as MenuItem;
            if (item == null) throw new ArgumentException("Not a menu item");

            if (!menu.Items.Contains(item))
                menu.Items.Add(item);
        }

        static void RemoveViewFromRegion(object view, Menu menu)
        {
            if (view is MenuItem item)
            {
                menu.Items.Remove(item);
            }
        }
    }
}
