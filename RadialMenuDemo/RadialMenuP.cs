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


        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(RadialMenu), new PropertyMetadata(true));


        public bool FillEmptyPlaces
        {
            get { return (bool)GetValue(FillEmptyPlacesProperty); }
            set { SetValue(FillEmptyPlacesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillEmptyPlaces.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillEmptyPlacesProperty =
            DependencyProperty.Register("FillEmptyPlaces", typeof(bool), typeof(RadialMenu), new PropertyMetadata(true));


        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(RadialMenu), new PropertyMetadata(false, new PropertyChangedCallback(OnIsExpandedChanged)));

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RadialMenu).IsExpandedChanged();
        }

        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(RadialMenu), new PropertyMetadata(0.0));

        public IRadialMenuItemsControl CurrentItem
        {
            get { return (IRadialMenuItemsControl)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(IRadialMenuItemsControl), typeof(RadialMenu), new PropertyMetadata(null, OnCurrentItemChanged));

        private static void OnCurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RadialMenu).OnCurrentItemChanged(e);
        }

        public int SectorCount
        {
            get { return (int)GetValue(SectorCountProperty); }
            set { SetValue(SectorCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SectorCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SectorCountProperty =
            DependencyProperty.Register("SectorCount", typeof(int), typeof(RadialMenu), new PropertyMetadata(0));


        public double PointerOverElementThickness
        {
            get { return (double)GetValue(PointerOverElementThicknessProperty); }
            set { SetValue(PointerOverElementThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointerOverElementThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointerOverElementThicknessProperty =
            DependencyProperty.Register("PointerOverElementThickness", typeof(double), typeof(RadialMenu), new PropertyMetadata(8.0));


        public double SelectedElementThickness
        {
            get { return (double)GetValue(SelectedElementThicknessProperty); }
            set { SetValue(SelectedElementThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedElementThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedElementThicknessProperty =
            DependencyProperty.Register("SelectedElementThickness", typeof(double), typeof(RadialMenu), new PropertyMetadata(8.0));




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
