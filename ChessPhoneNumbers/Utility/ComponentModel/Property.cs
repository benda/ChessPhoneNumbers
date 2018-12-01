using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPhoneNumbers.ComponentModel
{
    public class Property
    {
        public Property(Type type, string propertyName)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");

            Type = type;
            PropertyName = propertyName;
        }

        public Type Type { get; private set; }
        public string PropertyName { get; private set; }

        public override bool Equals(object obj)
        {
            Property otherProperty = obj as Property;

            if (object.ReferenceEquals(otherProperty, null))
            {
                return false;
            }

            return Type.Equals(otherProperty.Type) && PropertyName.Equals(otherProperty.PropertyName);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ PropertyName.GetHashCode();
        }
    }
}
