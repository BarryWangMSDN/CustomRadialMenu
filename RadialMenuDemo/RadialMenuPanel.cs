using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace RadialMenuDemo
{
    public class RadialMenuPanel : Panel
    {
        private RadialMenuItemsPresenter _radialMenuItemsPresenter = null;
        private RadialMenuItemsPresenter RadialMenuItemsPresenter
        {
            get
            {
                if (_radialMenuItemsPresenter == null)
                {
                    _radialMenuItemsPresenter = ItemsControl.GetItemsOwner(this) as RadialMenuItemsPresenter;
                }
                return _radialMenuItemsPresenter;
            }
        }

        private RadialMenu Menu
        {
            get
            {
                return RadialMenuItemsPresenter?.Menu;
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (var item in this.Children)
            {
                item.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

       
        
    }
}
