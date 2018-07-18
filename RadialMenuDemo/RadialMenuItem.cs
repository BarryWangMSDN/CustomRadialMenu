using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static RadialMenuDemo.RadialMenu;

namespace RadialMenuDemo
{
    public class  RadialMenuItem: Control,IRadialMenuItemsControl,INotifyPropertyChanged
    {
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