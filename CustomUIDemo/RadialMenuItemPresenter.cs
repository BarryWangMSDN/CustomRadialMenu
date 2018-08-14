using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Store;

namespace CustomUIDemo
{
    public class RadialMenuItemPresenter:ItemsControl
    {
        public RadialMenu Menu { get; internal set; }

        //
        // Summary:
        //     Prepares the specified element to display the specified item.
        //
        // Parameters:
        //   element:
        //     The element that's used to display the specified item.
        //
        //   item:
        //     The item to display.
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if(element is RadialMenuItem menuItem)
            {
                menuItem.SetMenu(Menu);
            }
            
            base.PrepareContainerForItemOverride(element, item);
        }
        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            base.ClearContainerForItemOverride(element, item);
        }

        protected async override void OnItemsChanged(object e)
        {
            base.OnItemsChanged(e);
            
        }
    }
}
