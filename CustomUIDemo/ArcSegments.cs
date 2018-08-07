using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CustomUIDemo
{
    public class ArcSegments : INotifyPropertyChanged
    {
        private ArcSegmentItem basepanel;

        public ArcSegmentItem BasePanel
        {
            get { return basepanel; }
            set { basepanel = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }


    public class ArcSegmentItem:INotifyPropertyChanged
    {
        private Point _startPoint;

        public Point StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
                OnPropertyChanged("StartPoint");
            }
        }

        private Point _endPoint;

        public Point EndPoint
        {
            get { return _endPoint; }
            set
            {
                _endPoint = value;
                OnPropertyChanged("EndPoint");
            }
        }

        private Size _size;

        public Size Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        private double _expandIconY;

        public double ExpandIconY
        {
            get { return _expandIconY; }
            set
            {
                _expandIconY = value;
                OnPropertyChanged("ExpandIconY");
            }
        }

        private double strokeThickness;

        public double StrokeThickness
        {
            get { return strokeThickness; }
            set
            {
                strokeThickness = value;
                OnPropertyChanged("StrokeThickness");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
