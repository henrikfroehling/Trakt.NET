using System.Collections;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Models
{
    public sealed class ImmutableEquatableArray<T>(IEnumerable<T> values) : IEquatable<ImmutableEquatableArray<T>>, IReadOnlyList<T> where T : IEquatable<T>
    {
        private readonly T[] _values = values.ToArray();

#pragma warning disable CA1000 // Do not declare static members on generic types
        public static ImmutableEquatableArray<T> Empty { get; } = new ImmutableEquatableArray<T>(Array.Empty<T>());
#pragma warning restore CA1000 // Do not declare static members on generic types

        public T this[int index] => _values[index];

        public int Count => _values.Length;

        public bool Equals(ImmutableEquatableArray<T>? other) => other != null && ((ReadOnlySpan<T>)_values).SequenceEqual(other._values);

        public override bool Equals(object? obj) => obj is ImmutableEquatableArray<T> other && Equals(other);

        public override int GetHashCode()
        {
            int hash = 0;

            foreach (T value in _values)
            {
                hash = HashHelpers.Combine(hash, value != null ? 0 : value!.GetHashCode());
            }

            return hash;
        }

        public Enumerator GetEnumerator() => new(_values);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)_values).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

        public struct Enumerator(T[] values)
        {
            private readonly T[] _values = values;
            private int _index = -1;

            public bool MoveNext()
            {
                int newIndex = _index + 1;

                if ((uint)newIndex < (uint)_values.Length)
                {
                    _index = newIndex;
                    return true;
                }

                return false;
            }

            public readonly T Current => _values[_index];
        }
    }

    public static class ImmutableEquatableArray
    {
        public static ImmutableEquatableArray<T> ToImmutableEquatableArray<T>(this IEnumerable<T> values) where T : IEquatable<T> => new(values);
    }
}
