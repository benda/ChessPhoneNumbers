using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections;

namespace ChessPhoneNumbers.ComponentModel
{
    public class ChangeStateMonitor
    {
        public event EventHandler HasChangesChanged;
        public event EventHandler MonitoredEntityPropertyChanged;

        private static Type _iCollectionType = typeof(ICollection<>);
        private static Type _iNotifyPropertyChangedType = typeof(INotifyPropertyChanged);
        private bool _hasChanges;
        private HashSet<Property> _ignoredProperties;

        public ChangeStateMonitor()
        {
            _ignoredProperties = new HashSet<Property>();
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnHasChangesChanged();
                }

                OnMonitoredEntityPropertyChanged();
            }
        }

        public HashSet<Property> IgnoredProperties
        {
            get { return _ignoredProperties; }
        }

        public void MonitorForChanges(INotifyPropertyChanged entity)
        {
            if (entity == null || entity is INotifyCollectionChanged)
            {
                return;
            }

            entity.PropertyChanged += new PropertyChangedEventHandler(entity_PropertyChanged);

            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                if (IsGenericCollection(property.PropertyType))
                {
                    IEnumerable collection = (IEnumerable)property.GetValue(entity, null);
                    MonitorCollectionForChanges(collection);
                }
                else if (_iNotifyPropertyChangedType.IsAssignableFrom(property.PropertyType))
                {
                    INotifyPropertyChanged notifyPropertyChangedEntity = (INotifyPropertyChanged)property.GetValue(entity, null);
                    MonitorForChanges(notifyPropertyChangedEntity);
                }
            }
        }

        private void MonitorCollectionForChanges(IEnumerable collection)
        {
            if (collection == null)
            {
                return;
            }

            if (collection is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)collection).CollectionChanged += new NotifyCollectionChangedEventHandler(collection_CollectionChanged);
            }

            foreach (object entity in collection)
            {
                MonitorForChanges(entity as INotifyPropertyChanged);
            }
        }

        private void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            HasChanges = true;

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                MonitorForChanges(e.NewItems[0] as INotifyPropertyChanged);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                StopMonitoringForChanges(e.OldItems[0] as INotifyPropertyChanged);
            }
        }

        private void StopMonitoringForChanges(INotifyPropertyChanged entity)
        {
            if (entity == null)
            {
                return;
            }

            entity.PropertyChanged -= new PropertyChangedEventHandler(entity_PropertyChanged);
        }

        private void entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (IgnoredProperties.Count > 0)
            {
                if (!IgnoredProperties.Contains(new Property(sender.GetType(),e.PropertyName)))
                {
                    HasChanges = true;
                }
            }
            else
            {
                HasChanges = true;
            }
        }

        /// <summary>
        /// Look for ICollection<> things, not IEnumerable, since that returns some things we don't care about [ie, strings]
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsGenericCollection(Type type)
        {
            bool isGenericCollection = false;

            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == _iCollectionType)
                {
                    isGenericCollection = true;
                    break;
                }
            }

            return isGenericCollection;
        }

        private void OnHasChangesChanged()
        {
            HasChangesChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnMonitoredEntityPropertyChanged()
        {
            MonitoredEntityPropertyChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
