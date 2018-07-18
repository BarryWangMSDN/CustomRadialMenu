using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RadialMenuDemo.RadialMenu;

namespace RadialMenuDemo
{
    public interface IRadialMenuItemsControl
    {
        RadialMenuItemCollection Items { get; }
       
        IEnumerable<RadialMenuItem> SelectedItems { get; }

        RadialMenuSelectionMode SelectionMode { get; set; }
    }
}
