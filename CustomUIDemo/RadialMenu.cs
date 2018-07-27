﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CustomUIDemo
{
    public  class RadialMenu : Control
    {
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
        private void OnCurrentItemChanged(DependencyPropertyChangedEventArgs e)
        {
            CurrentItemChanged?.Invoke(this, e);
        }

        public event DependencyPropertyChangedEventHandler CurrentItemChanged;



        public RadialMenu()
        {
            this.DefaultStyleKey = typeof(RadialMenu);
        }

      
    }

    [MarshalingBehavior(MarshalingType.Agile)]
    [Threading(ThreadingModel.Both)]
    [WebHostHidden]
    public sealed class RadialMenuItemCollection : ObservableCollection<RadialMenuItem>
    {
        //
    }

}
