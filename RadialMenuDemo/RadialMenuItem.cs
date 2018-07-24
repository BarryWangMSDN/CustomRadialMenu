using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using static RadialMenuDemo.RadialMenu;

namespace RadialMenuDemo
{
    public class  RadialMenuItem: Control,IRadialMenuItemsControl,INotifyPropertyChanged
    {
        private FontIcon _expandIcon;
        private Grid _expandButtonArea;
        private Path _hitTestElement;

        internal FontIcon ExpandIcon
        {
            get
            {
                return _expandIcon;
            }
        }

        public string GroupName { get; set; }

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(RadialMenuItem), new PropertyMetadata(null));



        public object ToolTip
        {
            get { return (object)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register("ToolTip", typeof(object), typeof(RadialMenuItem), new PropertyMetadata(null));



        public int SectorCount
        {
            get { return (int)GetValue(SectorCountProperty); }
            set { SetValue(SectorCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SectorCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SectorCountProperty =
            DependencyProperty.Register("SectorCount", typeof(int), typeof(RadialMenuItem), new PropertyMetadata(0));


        public event EventHandler IsSelectedChanged;

        public RadialMenuSelectionMode SelectionMode
        {
            get { return (RadialMenuSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectionMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(RadialMenuSelectionMode), typeof(RadialMenuItem), new PropertyMetadata(RadialMenuSelectionMode.None));


        public bool IsSelectedEnable
        {
            get { return (bool)GetValue(IsSelectedEnableProperty); }
            set { SetValue(IsSelectedEnableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelectedEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedEnableProperty =
            DependencyProperty.Register("IsSelectedEnable", typeof(bool), typeof(RadialMenuItem), new PropertyMetadata(true));

       

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RadialMenuItem).OnIsSelectedChanged();
        }
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(RadialMenuItem), new PropertyMetadata(false, OnIsSelectedChanged));


        protected void OnIsSelectedChanged()
        {
            if (!(IsSelectedEnable && !HasItems))
            {
                return;
            }
            if (IsSelected)
            {
                VisualStateManager.GoToState(this, "IsSelected", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", false);
            }
            IsSelectedChanged?.Invoke(this, null);
        }

        public virtual bool HasItems
        {
            get
            {
                return _items.Where(x => x.Visibility == Visibility.Visible).Count() > 0;
            }
        }
        public virtual IEnumerable<RadialMenuItem> SelectedItems
        {
            get
            {
                return Items.Where(x => x.IsSelected);
            }
        }


        #region IRadialMenuItemsControl
        private RadialMenuItemCollection _items;
        public virtual RadialMenuItemCollection Items => _items;

        #endregion


        private RadialMenu _menu;

        private IRadialMenuItemsControl _parentItem;
        public RadialMenu Menu => _menu;
        public IRadialMenuItemsControl ParentItem => _parentItem;

        internal void SetMenu(RadialMenu menu)
        {
            _menu = menu;
          //  _parentItem = menu?.CurrentItem;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}