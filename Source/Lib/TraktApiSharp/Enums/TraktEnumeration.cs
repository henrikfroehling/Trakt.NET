namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
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

        /// <summary>Returns the numeric value of the enumeration.</summary>
        public int Value { get; }

        /// <summary>Returns the enumeration name for object properties.</summary>
        public string ObjectName { get; }

        /// <summary>Returns the enumeration name for URI path parameters.</summary>
        public string UriName { get; }

        /// <summary>
        /// Returns the human readable name of the enumeration.
        /// See also <seealso cref="ToString()" />.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Returns the human readable name of the enumeration.
        /// See also <seealso cref="DisplayName" />.
        /// </summary>
        public override string ToString() => DisplayName;

        /// <summary>
        /// Compares the <see cref="Value" /> of this enumeration with the value of
        /// another enumeration.
        /// </summary>
        /// <param name="other">The other enumeration to compare with.</param>
        /// <returns>An indication of their relative values.</returns>
        public int CompareTo(object other) => Value.CompareTo(((TraktEnumeration)other).Value);

        /// <summary>Returns, whether this enumeration instance is equal to another enumeration instance.</summary>
        /// <param name="obj">The other enumeration instance to compare with.</param>
        /// <returns>True, if both enumeration instances are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var otherValue = obj as TraktEnumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        /// <summary>Returns the hash code of this enumeration.</summary>
        /// <returns>An hash code of this enumeration.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>Returns a list of all enumerations of an enumeration of type T.</summary>
        /// <typeparam name="T">The enumeration, of which a list of all enumerations should be returned.</typeparam>
        /// <returns>A list of all enumerations of an enumeration of type T.</returns>
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

        /// <summary>Calculates the absolute difference of the <see cref="Value" /> for two enumerations.</summary>
        /// <param name="first">The first enumeration.</param>
        /// <param name="second">The second enumeration.</param>
        /// <returns>The absolute difference of the <see cref="Value" /> for two enumerations.</returns>
        public static int AbsoluteDifference(TraktEnumeration first, TraktEnumeration second) => Math.Abs(first.Value - second.Value);

        /// <summary>Creates an enumeration of type T from the given value.</summary>
        /// <typeparam name="T">The type of the enumeration, which should be created.</typeparam>
        /// <param name="value">The value from which the enumeration should be created.</param>
        /// <returns>
        /// An enumeration of type T or null, if the value could not be found
        /// in the available values for the enumeration.
        /// </returns>
        public static T FromValue<T>(int value) where T : TraktEnumeration, new() => Search<T>(e => e.Value == value);

        /// <summary>Creates an enumeration of type T from the given object name.</summary>
        /// <typeparam name="T">The type of the enumeration, which should be created.</typeparam>
        /// <param name="objectName">The object name from which the enumeration should be created.</param>
        /// <returns>
        /// An enumeration of type T or null, if the value could not be found
        /// in the available values for the enumeration.
        /// </returns>
        public static T FromObjectName<T>(string objectName) where T : TraktEnumeration, new() => Search<T>(e => e.ObjectName == objectName);

        /// <summary>Creates an enumeration of type T from the given URI name.</summary>
        /// <typeparam name="T">The type of the enumeration, which should be created.</typeparam>
        /// <param name="uriName">The URI name from which the enumeration should be created.</param>
        /// <returns>
        /// An enumeration of type T or null, if the value could not be found
        /// in the available values for the enumeration.
        /// </returns>
        public static T FromUriName<T>(string uriName) where T : TraktEnumeration, new() => Search<T>(e => e.UriName == uriName);

        /// <summary>Creates an enumeration of type T from the given display name.</summary>
        /// <typeparam name="T">The type of the enumeration, which should be created.</typeparam>
        /// <param name="displayName">The display name from which the enumeration should be created.</param>
        /// <returns>
        /// An enumeration of type T or null, if the value could not be found
        /// in the available values for the enumeration.
        /// </returns>
        public static T FromDisplayName<T>(string displayName) where T : TraktEnumeration, new() => Search<T>(e => e.DisplayName == displayName);

        private static T Search<T>(Func<TraktEnumeration, bool> predicate) where T : TraktEnumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            return matchingItem != null ? matchingItem as T : null;
        }
    }

    public class TraktEnumerationConverter<T> : JsonConverter where T : TraktEnumeration, new()
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
            {
                var derivedEnum = Activator.CreateInstance(typeof(T));
                return derivedEnum;
            }

            return TraktEnumeration.FromObjectName<T>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumeration = (T)value;
            writer.WriteValue(enumeration.ObjectName);
        }
    }
}
