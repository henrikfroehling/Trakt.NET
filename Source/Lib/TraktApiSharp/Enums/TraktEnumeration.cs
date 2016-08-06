namespace TraktApiSharp.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class TraktEnumeration : IComparable
    {
        protected TraktEnumeration() { }

        protected TraktEnumeration(int value, string objectName, string uriName, string displayName)
        {
            Value = value;
            ObjectName = objectName;
            UriName = uriName;
            DisplayName = displayName;
        }

        public int Value { get; }

        public string ObjectName { get; }

        public string UriName { get; }

        public string DisplayName { get; }

        public override string ToString() => DisplayName;

        public int CompareTo(object other) => Value.CompareTo(((TraktEnumeration)other).Value);

        public override bool Equals(object obj)
        {
            var otherValue = obj as TraktEnumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public abstract IEnumerable<TraktEnumeration> AllEnumerations { get; }

        public static int AbsoluteDifference(TraktEnumeration first, TraktEnumeration second) => Math.Abs(first.Value - second.Value);

        public static T FromValue<T>(int value) where T : TraktEnumeration, new()
        {
            var enumType = typeof(T);
            var derivedEnum = (T)Activator.CreateInstance(enumType);

            var matchingItem = derivedEnum.AllEnumerations.FirstOrDefault(e => e.Value == value);

            if (matchingItem == null)
                return null;

            return matchingItem as T;
        }

        public static T FromObjectName<T>(string objectName) where T : TraktEnumeration, new()
        {
            var enumType = typeof(T);
            var derivedEnum = (T)Activator.CreateInstance(enumType);

            var matchingItem = derivedEnum.AllEnumerations.FirstOrDefault(e => e.ObjectName == objectName);

            if (matchingItem == null)
                return null;

            return matchingItem as T;
        }

        public static T FromUriName<T>(string uriName) where T : TraktEnumeration, new()
        {
            var enumType = typeof(T);
            var derivedEnum = (T)Activator.CreateInstance(enumType);

            var matchingItem = derivedEnum.AllEnumerations.FirstOrDefault(e => e.UriName == uriName);

            if (matchingItem == null)
                return null;

            return matchingItem as T;
        }

        public static T FromDisplayName<T>(string displayName) where T : TraktEnumeration, new()
        {
            var enumType = typeof(TraktEnumeration);
            var derivedEnum = (T)Activator.CreateInstance(enumType);

            var matchingItem = derivedEnum.AllEnumerations.FirstOrDefault(e => e.DisplayName == displayName);

            if (matchingItem == null)
                return null;

            return matchingItem as T;
        }
    }
}
