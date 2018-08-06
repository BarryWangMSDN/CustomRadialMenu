using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CustomUIDemo
{
    public sealed class NavigationButton : ContentControl
    {
        private Ellipse _backgroundElement;
        public event RoutedEventHandler Click;
        public NavigationButton()
        {
            this.DefaultStyleKey = typeof(NavigationButton);
        }

        protected override void OnApplyTemplate()
        {
            _backgroundElement = GetTemplateChild("BackgroundElement") as Ellipse;
            base.OnApplyTemplate();
        }

        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            Click?.Invoke(this, new RoutedEventArgs());
            base.OnTapped(e);
        }
        }
}
