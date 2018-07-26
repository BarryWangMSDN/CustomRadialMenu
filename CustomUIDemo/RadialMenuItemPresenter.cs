using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomUIDemo
{
    public class RadialMenuItemPresenter:ItemsControl
    {
        public RadialMenu Menu { get; internal set; }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (element is RadialMenuItem menuItem)
            {
                menuItem.SetMenu(Menu);
            }
            else
            {

            }
            base.PrepareContainerForItemOverride(element, item);
        }

    }
}
