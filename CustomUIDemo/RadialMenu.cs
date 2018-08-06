using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CustomUIDemo
{
    [ContentProperty(Name = "MyItems")]
    [Bindable]
    public class RadialMenu : Control, IRadialMenuItemsControl
    {
        #region fields
        private RadialMenuItemCollection _items;
        private RadialMenuItemPresenter _currentItemPresenter;
        private Grid _contentGrid;
        internal NavigationButton _navigationButtion;
        #endregion

        #region animationready
        Visual _contentGridVisual;
        Compositor _compositor;
        ScalarKeyFrameAnimation rotationAnimation;
        Vector3KeyFrameAnimation scaleAnimation;
        #endregion

        #region IRadialMenuItemsControl
        //Implement the interface, also set the content
        public RadialMenuItemCollection MyItems
        {
            get
            {
                return _items;
            }
   
        }
        #endregion
        //public IRadialMenuItemsControl CurrentItem
        //{
        //    get { return (IRadialMenuItemsControl)GetValue(CurrentItemProperty); }
        //    set { SetValue(CurrentItemProperty, value); }
        //}


        //// Using a DependencyProperty as the backing store for CurrentItem.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CurrentItemProperty =
        //    DependencyProperty.Register("CurrentItem", typeof(IRadialMenuItemsControl), typeof(RadialMenu), new PropertyMetadata(null, OnCurrentItemChanged));

        //private static void OnCurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    (d as RadialMenu).OnCurrentItemChanged(e);
        //}
        //private void OnCurrentItemChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    CurrentItemChanged?.Invoke(this, e);
        //}

        //public event DependencyPropertyChangedEventHandler CurrentItemChanged;

        #region DP
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(RadialMenu), new PropertyMetadata(true, new PropertyChangedCallback(OnIsExpandedChanged)));
        #endregion

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RadialMenu).IsExpandedChanged();
        }

        private void IsExpandedChanged()
        {        
            if (IsExpanded)
            {
                Expand(); 
            }
            else
            {

                Collapse();
            }
           
        }

        public RadialMenu()
        {
            this.DefaultStyleKey = typeof(RadialMenu);
            _items = new RadialMenuItemCollection();
        }


        protected override void OnApplyTemplate()
        {
            _contentGrid = GetTemplateChild("ContentGrid") as Grid;
            _navigationButtion = GetTemplateChild("NavigationButton") as NavigationButton;
            _navigationButtion.Click += _navigationButtion_Click;
            PrepareAnimation();
            base.OnApplyTemplate();
        }

        private void _navigationButtion_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        void PrepareAnimation()
        {
            _contentGridVisual = ElementCompositionPreview.GetElementVisual(_contentGrid);
            _compositor = _contentGridVisual.Compositor;
            rotationAnimation = _compositor.CreateScalarKeyFrameAnimation();
            scaleAnimation = _compositor.CreateVector3KeyFrameAnimation();
            var easing = _compositor.CreateLinearEasingFunction();
            _contentGrid.SizeChanged += (s, e) =>
            {
                _contentGridVisual.CenterPoint = new Vector3((float)_contentGrid.ActualWidth / 2.0f, (float)_contentGrid.ActualHeight / 2.0f, 0);
            };
            scaleAnimation.InsertKeyFrame(0.0f, new Vector3() { X = 0.0f, Y = 0.0f, Z = 0.0f });
            scaleAnimation.InsertKeyFrame(1.0f, new Vector3() { X = 1.0f, Y = 1.0f, Z = 0.0f }, easing);

            rotationAnimation.InsertKeyFrame(0.0f, -90.0f);
            rotationAnimation.InsertKeyFrame(1.0f, 0.0f, easing);
        }

        void Expand()
        {
            if (_contentGridVisual != null)
            {
                scaleAnimation.Direction = AnimationDirection.Normal;
                rotationAnimation.Direction = AnimationDirection.Normal;
                scaleAnimation.Duration = TimeSpan.FromSeconds(0.2);
                rotationAnimation.Duration = TimeSpan.FromSeconds(0.2);            
                _contentGridVisual.StartAnimation(nameof(_contentGridVisual.Scale), scaleAnimation);
                _contentGridVisual.StartAnimation(nameof(_contentGridVisual.RotationAngleInDegrees), rotationAnimation);
            }
        }

        void Collapse()
        {
            if (_contentGridVisual != null)
            {
                scaleAnimation.Direction = AnimationDirection.Reverse;
                rotationAnimation.Direction = AnimationDirection.Reverse;
                scaleAnimation.Duration = TimeSpan.FromSeconds(0.2);
                rotationAnimation.Duration = TimeSpan.FromSeconds(0.2);
                _contentGridVisual.StartAnimation(nameof(_contentGridVisual.Scale), scaleAnimation);
                _contentGridVisual.StartAnimation(nameof(_contentGridVisual.RotationAngleInDegrees), rotationAnimation);
            }
        }
    }

    [MarshalingBehavior(MarshalingType.Agile)]
    [Threading(ThreadingModel.Both)]
    [WebHostHidden]
    public sealed class RadialMenuItemCollection : ObservableCollection<RadialMenuItem>
    {
        
    }

}
