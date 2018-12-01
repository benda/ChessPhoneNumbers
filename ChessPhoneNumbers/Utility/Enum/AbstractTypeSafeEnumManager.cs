using System;
using System.Collections.Generic;
using System.Text;

namespace ChessPhoneNumbers.TypeSafeEnum
{
    internal class AbstractTypeSafeEnumManager
    {
        private Dictionary<Type, Dictionary<string, AbstractTypeSafeEnum>> _enums = new Dictionary<Type, Dictionary<string, AbstractTypeSafeEnum>>();
        private int[] _possibleFlagValues = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524888, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 6710864, 67108864, 1324217728, 268435456, 536870912 };

        public int AddEnum(Type type, AbstractTypeSafeEnum instance)
        {   
            if (!_enums.ContainsKey(type))
            {
                _enums.Add(type, new Dictionary<string, AbstractTypeSafeEnum>());
            }

            Dictionary<string, AbstractTypeSafeEnum> enumValues = _enums[type];
            enumValues.Add(instance.Value.ToUpperInvariant(), instance);

            if (AbstractTypeSafeEnum.SupportsMultipleValues(type))
            {
                if (enumValues.Count < _possibleFlagValues.Length)
                {
                    return _possibleFlagValues[enumValues.Count - 1];
                }
                else
                {
                    throw new InvalidOperationException("No more than 30 enum values are supported.");
                }
            }
            else
            {
                return -1;
            }
        }

        public T GetEnum<T>(string[] s) where T : AbstractTypeSafeEnum
        {
            Type type = typeof(T);

            if (!_enums.ContainsKey(type))
            {
                return null;
            }

            if (s.Length == 1)
            {
                string value = s[0].ToUpperInvariant();
                if (_enums[type].ContainsKey(value))
                {
                    return (T)_enums[type][value];
                }
            }
            else
            {
                if (!AbstractTypeSafeEnum.SupportsMultipleValues(type))
                {
                //    throw new ArgumentException(Resources.EnumDoesNotSupportMultipleValues);
                }

                List<T> values = new List<T>(); 

                foreach (string v in s)
                {
                    string value = v.ToUpperInvariant();

                    if (_enums[type].ContainsKey(value))
                    {
                        values.Add((T)_enums[type][value]);
                    }
                }

                return AbstractTypeSafeEnum.CombineValues<T>(values.ToArray());
            }

            return null;
        }

        public IList<T> GetValuesForEnum<T>() where T : AbstractTypeSafeEnum
        {
            Type type = typeof(T);

            ICollection<AbstractTypeSafeEnum> enumValues = _enums[type].Values;
            IList<T> valuesAsList = new List<T>(enumValues.Count);

            foreach (AbstractTypeSafeEnum val in enumValues)
            {
                valuesAsList.Add((T)val);
            }

            return valuesAsList;
        }

        public int GetNumericValueForEnum(Type type)
        {
            return _enums[type].Values.Count;
        }
    }
}
