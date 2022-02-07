﻿using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace PrismOutlook.Core.Regions
{
    public class XamRibbonRegionAdapter : RegionAdapterBase<Menu>
    {
        public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Menu regionTarget)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        AddViewToRegion(view, regionTarget);
                    }

                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        RemoveViewFromRegion(view, regionTarget);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        static void AddViewToRegion(object view, Menu xamRibbon)
        {
            if (view is MenuItem ribbonTabItem)
            {
                xamRibbon.Items.Add(ribbonTabItem);
            }
        }

        static void RemoveViewFromRegion(object view, Menu xamRibbon)
        {
            if (view is MenuItem ribbonTabItem)
            {
                xamRibbon.Items.Remove(ribbonTabItem);
            }
        }
    }
}
