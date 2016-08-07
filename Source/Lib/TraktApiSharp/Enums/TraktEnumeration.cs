namespace TraktApiSharp.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class TraktEnumeration : IComparable
    {
        protected const string DISPLAY_NAME_UNSPECIFIED = "Unspecified";

        protected TraktEnumeration() : this(0, string.Empty, string.Empty, DISPLAY_NAME_UNSPECIFIED) { }

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

        public static IEnumerable<T> GetAll<T>() where T : TraktEnumeration, new()
        {
            var derivedEnumType = typeof(T);
            var derivedEnum = Activator.CreateInstance(derivedEnumType);
            var fields = derivedEnumType.GetRuntimeFields().Where(f => f.FieldType == derivedEnumType && f.IsStatic && f.IsInitOnly);

            foreach (var field in fields)
            {
                var value = field.GetValue(derivedEnum) as T;

                if (value != null)
                    yield return value;
            }
        }

        public static int AbsoluteDifference(TraktEnumeration first, TraktEnumeration second) => Math.Abs(first.Value - second.Value);

        public static T FromValue<T>(int value) where T : TraktEnumeration, new() => Search<T>(e => e.Value == value);
        public static T FromObjectName<T>(string objectName) where T : TraktEnumeration, new() => Search<T>(e => e.ObjectName == objectName);
        public static T FromUriName<T>(string uriName) where T : TraktEnumeration, new() => Search<T>(e => e.UriName == uriName);
        public static T FromDisplayName<T>(string displayName) where T : TraktEnumeration, new() => Search<T>(e => e.DisplayName == displayName);

        private static T Search<T>(Func<TraktEnumeration, bool> predicate) where T : TraktEnumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            return matchingItem != null ? matchingItem as T : null;
        }
    }
}
