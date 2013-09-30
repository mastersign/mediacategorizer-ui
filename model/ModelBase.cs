using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    abstract class ModelBase : INotifyPropertyChanged, IChangeTracking
    {
        private bool isChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            IsChanged = true;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void ChildPropertyChangedHandler(object sender, PropertyChangedEventArgs ea)
        {
            IsChanged = true;
        }

        protected void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs ea)
        {
            IsChanged = true;
            foreach (var child in ea.OldItems.OfType<INotifyPropertyChanged>())
            {
                child.PropertyChanged -= ChildPropertyChangedHandler;
            }
            foreach (var child in ea.NewItems.OfType<INotifyPropertyChanged>())
            {
                child.PropertyChanged += ChildPropertyChangedHandler;
            }
        }

        public bool IsChanged
        {
            get { return isChanged; }
            private set
            {
                if (value == isChanged) return;
                isChanged = value;
                OnPropertyChanged("IsChanged");
            }
        }

        public void AcceptChanges()
        {
            IsChanged = false;
        }
    }
}
