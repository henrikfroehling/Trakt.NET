namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A Trakt list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktListResponse<TResponseContentType>
        : TraktResponse<IList<TResponseContentType>>,
          ITraktListResponse<TResponseContentType>,
          IEquatable<TraktListResponse<TResponseContentType>>,
          IEqualityComparer<TraktListResponse<TResponseContentType>>
    {
        /// <summary>
        /// Compares this instance with another <see cref="TraktListResponse{TResponseContentType}" /> instance.
        /// </summary>
        /// <param name="other">Another <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be compared with this instance.</param>
        /// <returns>True, of both instances are equal, otherwise false.</returns>
        public bool Equals(TraktListResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other);
        }

        public bool Equals(TraktListResponse<TResponseContentType> left, TraktListResponse<TResponseContentType> right)
            => left.Equals(right);

        /// <summary>Gets the enumerator for the list in this response instance.</summary>
        /// <returns>An enumerator for the list in this response instance.</returns>
        public IEnumerator<TResponseContentType> GetEnumerator() => Value.GetEnumerator();

        public int GetHashCode(TraktListResponse<TResponseContentType> obj) => obj.GetHashCode();

        /// <summary>Gets the enumerator for the list in this response instance.</summary>
        /// <returns>An enumerator for the list in this response instance.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Enables implicit conversion to <see cref="TraktListResponse{TResponseContentType}" /> for this type.</summary>
        /// <param name="value">The <see cref="List{TResponseContentType}" /> instance, which will be converted to <see cref="TraktListResponse{TResponseContentType}" />.</param>
        public static implicit operator TraktListResponse<TResponseContentType>(List<TResponseContentType> value)
            => new()
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktListResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;

        public TResponseContentType this[int index]
        {
            get => Value != null ? Value[index] : default;
            
            set
            {
                if (Value != null)
                    Value[index] = value;
            }
        }

        public int Count => Value != null ? Value.Count : 0;

        public bool IsReadOnly => Value != null ? Value.IsReadOnly : false;

        public void Add(TResponseContentType item) => Value?.Add(item);

        public void Clear() => Value?.Clear();

        public bool Contains(TResponseContentType item) => Value != null ? Value.Contains(item) : false;

        public void CopyTo(TResponseContentType[] array, int arrayIndex) => Value?.CopyTo(array, arrayIndex);

        public int IndexOf(TResponseContentType item) => Value != null ? Value.IndexOf(item) : -1;

        public void Insert(int index, TResponseContentType item) => Value?.Insert(index, item);

        public bool Remove(TResponseContentType item) => Value != null ? Value.Remove(item) : false;

        public void RemoveAt(int index) => Value?.RemoveAt(index);
    }
}
