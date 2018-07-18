using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace RadialMenuDemo
{
    public partial class RadialMenu
    {
        #region DP
        public double ExpandAreaThickness
        {
            get { return (double)GetValue(ExpandAreaThicknessProperty); }
            set { SetValue(ExpandAreaThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExpandAreaThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpandAreaThicknessProperty =
            DependencyProperty.Register("ExpandAreaThickness", typeof(double), typeof(RadialMenu), new PropertyMetadata(25.0));






        #region NavigationButton

        public double RadialMenuNavigationButtonSize
        {
            get { return (double)GetValue(RadialMenuNavigationButtonSizeProperty); }
            set { SetValue(RadialMenuNavigationButtonSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadialMenuNavigationButtonSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadialMenuNavigationButtonSizeProperty =
            DependencyProperty.Register("RadialMenuNavigationButtonSize", typeof(double), typeof(RadialMenu), new PropertyMetadata(45.0));

        public object NavigationButtonIcon
        {
            get { return (object)GetValue(NavigationButtonIconProperty); }
            set { SetValue(NavigationButtonIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationButtonIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationButtonIconProperty =
            DependencyProperty.Register("NavigationButtonIcon", typeof(object), typeof(RadialMenu), new PropertyMetadata((char)0xE115));

        public object NavigationButtonBackIcon
        {
            get { return (object)GetValue(NavigationButtonBackIconProperty); }
            set { SetValue(NavigationButtonBackIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationButtonBackIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationButtonBackIconProperty =
            DependencyProperty.Register("NavigationButtonBackIcon", typeof(object), typeof(RadialMenu), new PropertyMetadata((char)0xE2A6));







        #endregion

        [MarshalingBehavior(MarshalingType.Agile)]
        [Threading(ThreadingModel.Both)]
        [WebHostHidden]
        public sealed class RadialMenuItemCollection : ObservableCollection<RadialMenuItem>
        {
            
        }

        #endregion
    }
}
