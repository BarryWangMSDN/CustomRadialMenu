using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace RadialMenuDemo
{
    public class RadialMenuNavigationButton : ContentControl
    {
        private Ellipse _backgroundElement;
        public event RoutedEventHandler Click;
        public RadialMenuNavigationButton()
        {
            this.DefaultStyleKey = typeof(RadialMenuNavigationButton);
        }

        protected override void OnApplyTemplate()
        {
            _backgroundElement = GetTemplateChild("BackgroundElement") as Ellipse;
            if (!DesignMode.DesignModeEnabled)
            {
                GoToStateCollapse();
            }

            base.OnApplyTemplate();
        }

        public void GoToStateExpand()
        {
            VisualStateManager.GoToState(this, "Expand", false);
        }

        public void GoToStateCollapse()
        {
            VisualStateManager.GoToState(this, "Collapse", false);
        }

        public void GoToStateNumeric()
        {
            VisualStateManager.GoToState(this, "Numeric", false);
        }

        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            Click?.Invoke(this, new RoutedEventArgs());
            base.OnTapped(e);
        }
    }
}
