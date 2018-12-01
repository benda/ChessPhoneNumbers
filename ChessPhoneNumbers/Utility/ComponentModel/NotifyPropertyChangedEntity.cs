using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ChessPhoneNumbers.ComponentModel
{
    [Serializable]
    public class NotifyPropertyChangedEntity : INotifyPropertyChanged
    {
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
