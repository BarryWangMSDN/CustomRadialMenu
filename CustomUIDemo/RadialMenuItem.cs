using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CustomUIDemo
{
    public class RadialMenuItem : Control
    {

        private RadialMenu _menu;
        private IRadialMenuItemsControl _parentItem;

        public RadialMenu Menu => _menu;
        public IRadialMenuItemsControl ParentItem => _parentItem;

        internal void SetMenu(RadialMenu menu)
        {
            _menu = menu;
            _parentItem = menu?.CurrentItem;
        }
    }
}
