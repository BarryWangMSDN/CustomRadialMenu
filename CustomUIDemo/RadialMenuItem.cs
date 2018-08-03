using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace CustomUIDemo
{
    [ContentProperty(Name = "MyItems")]
    [Windows.UI.Xaml.Data.Bindable]
    public class RadialMenuItem : Control, IRadialMenuItemsControl, INotifyPropertyChanged
    {
       
        public RadialMenuItem()
        {
            this.DefaultStyleKey = typeof(RadialMenuItem);
            PrepareElements();          
        }



        private RadialMenu _menu;
        private IRadialMenuItemsControl _parentItem;

        public RadialMenu Menu => _menu;
        public IRadialMenuItemsControl ParentItem => _parentItem;

        #region IRadialMenuItemsControl
        private RadialMenuItemCollection _items;
        public virtual RadialMenuItemCollection MyItems => _items;


        #endregion

        #region DP
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(RadialMenuItem), new PropertyMetadata(null));


        public double ContentAngle
        {
            get { return (double)GetValue(ContentAngleProperty); }
            set { SetValue(ContentAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentAngleProperty =
            DependencyProperty.Register("ContentAngle", typeof(double), typeof(RadialMenuItem), new PropertyMetadata(0.0));
        #endregion


        internal void SetMenu(RadialMenu menu)
        {
            _menu = menu;
            //_parentItem = menu?.CurrentItem;
        }

        protected void PrepareElements()
        {
            _items = new RadialMenuItemCollection();
            _items.CollectionChanged += _items_CollectionChanged;
        }

        private void _items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("HasItems");
        }

        public virtual bool HasItems
        {
            get
            {
                return _items.Where(x => x.Visibility == Visibility.Visible).Count() > 0;
            }
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
