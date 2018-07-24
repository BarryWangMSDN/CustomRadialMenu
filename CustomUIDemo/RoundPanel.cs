using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CustomUIDemo
{
    public class RoundPanel : Panel
    {
        public RoundPanel()
        {

        }

        protected override Size MeasureOverride(Size availableSize)
        {         
            //loop through each Child, call Measure on each
            foreach (UIElement child in Children)
            {
                child.Measure(new Size(availableSize.Width, availableSize.Height)); // TODO determine how much space the panel allots for this child, that's what you pass to Measure      
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0)
                return finalSize;

            var count = Children.Count;
            //Get the radius of the available size.
            double radius = Math.Min(finalSize.Width, finalSize.Height) * 0.5;
            //child angle
            double childAngle = 360.0 / (Math.Max((double)count, 2));
            //sin
            var sin = Sin(childAngle / 2);
            //cos
            var cos = Cos(childAngle / 2);
            //SampleRect
            var SampleRect = new Rect { Width = 2 * sin * radius, Height = radius };
            SampleRect.X = radius - SampleRect.Width / 2.0;
            //loop
            for (int i=1;i<Children.Count;i++)
            {
                var element = Children[i];
                RotateTransform transform = new RotateTransform();
                transform.CenterX = SampleRect.Width / 2.0;
                transform.CenterY = SampleRect.Height;
                var angle = childAngle * i;
                transform.Angle = angle;
                element.RenderTransform = transform;
                element.Arrange(SampleRect);
            }
            return base.ArrangeOverride(finalSize);

        }

        private double Sin(double angle)
        {
            return Math.Round(Math.Sin(angle / 180 * Math.PI), 5);
        }

        private double Cos(double angle)
        {
            return Math.Round(Math.Cos(angle / 180 * Math.PI), 5);
        }

    }
}
