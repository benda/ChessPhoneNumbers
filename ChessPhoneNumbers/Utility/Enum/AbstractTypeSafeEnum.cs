using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ChessPhoneNumbers.TypeSafeEnum
{
    [Serializable]
    public abstract class AbstractTypeSafeEnum : IComparable
    {
        private static AbstractTypeSafeEnumManager _enumManager = new AbstractTypeSafeEnumManager();

        private string _value;
        private string _displayName;
        private int _flagValue;
        private int _numericValue;
        private const string EnumValueSeparator = "###";

        protected AbstractTypeSafeEnum(string value) : this(value, value)
        {
        }

        protected AbstractTypeSafeEnum(string value, string displayName)
        {
            this._value = value;
            this._displayName = displayName;
            this._flagValue = _enumManager.AddEnum(GetType(), this);
            this._numericValue = _enumManager.GetNumericValueForEnum(GetType());
        }

        /// <summary>
        /// This constructor is not meant to be used by any subtype code.
        /// </summary>
        protected AbstractTypeSafeEnum()
        {
            if (!SupportsMultipleValues(GetType()))
            {
            //    throw new InvalidOperationException(Resources.EnumDoesNotSupportMultipleValues);
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public string Value
        {
            get { return _value; }
         }

        public string DisplayName
        {
            get { return _displayName; }
        }

        protected static T FromString<T>(string s) where T : AbstractTypeSafeEnum
        {
            return _enumManager.GetEnum<T>(s.Split(new string[]{EnumValueSeparator}, StringSplitOptions.RemoveEmptyEntries));
        }

        protected static IList<T> GetValues<T>() where T : AbstractTypeSafeEnum
        {
            return _enumManager.GetValuesForEnum<T>();
        }

        public override bool Equals(object obj)
        {
            AbstractTypeSafeEnum otherObj = obj as AbstractTypeSafeEnum;
            if (otherObj != null && otherObj.GetType().Equals(GetType()))
            {
                return otherObj.Value == Value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(AbstractTypeSafeEnum a, AbstractTypeSafeEnum b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(AbstractTypeSafeEnum a, AbstractTypeSafeEnum b)
        {
            return !(a == b);
        }

        public static bool IsSet(AbstractTypeSafeEnum enumToCheck, AbstractTypeSafeEnum flagToCheckFor)
        {
            if(!SupportsMultipleValues(enumToCheck.GetType()))
            {
             //   throw new ArgumentException(Resources.EnumDoesNotSupportMultipleValues);
            }
            if (flagToCheckFor.Value.Contains(EnumValueSeparator) && !enumToCheck.Value.Contains(EnumValueSeparator))
            {
                return ((enumToCheck._flagValue & flagToCheckFor._flagValue) == enumToCheck._flagValue);
            }
            else
            {
                return ((enumToCheck._flagValue & flagToCheckFor._flagValue) == flagToCheckFor._flagValue);
            }       
        }

        public static T CombineValues<T>(params T[] flags) where T : AbstractTypeSafeEnum
        {
            if (flags == null) throw new ArgumentNullException("flags");
            if (flags.Length < 2) throw new ArgumentException("Two or more values must be specified.");

            if (!SupportsMultipleValues(typeof(T)))
            {
         //       throw new ArgumentException(Resources.EnumDoesNotSupportMultipleValues);
            }

            int flagValue = 0;
            StringBuilder newValue = new StringBuilder();
            StringBuilder newDisplayName = new StringBuilder();

            bool addenumValueSeparator = false;
            foreach (T t in flags)
            {
                if (!ReferenceEquals(t, null))
                {
                    if (addenumValueSeparator)
                    {
                        newValue.Append(EnumValueSeparator);
                    }
                    flagValue |= t._flagValue;
                    newValue.Append(t._value);
                    addenumValueSeparator = true;
                    newDisplayName.Append(t.DisplayName);
                }
            }

            T newEnum = Activator.CreateInstance<T>();
            newEnum._flagValue = flagValue;
            newEnum._value = newValue.ToString();
            newEnum._displayName = newDisplayName.ToString();
            newEnum._numericValue = -1;

            return newEnum;
        }

        internal static bool SupportsMultipleValues(Type enumType)
        {
            foreach (object attribute in enumType.GetCustomAttributes(true))
            {
             //   if (attribute is MultiValuedEnumAttribute)
                {
                    return true;
                }
            }

            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is AbstractTypeSafeEnum && obj.GetType().Equals(GetType()))
            {
                AbstractTypeSafeEnum tse = (AbstractTypeSafeEnum)obj;

                if (SupportsMultipleValues(GetType()))
                {
                    return _flagValue.CompareTo(tse._flagValue);
                }
                else
                {
                    return _numericValue.CompareTo(tse._numericValue);
                }
            }

            throw new ArgumentException("Object is not an AbstractTypeSafeEnum");  
        }
    }
}
