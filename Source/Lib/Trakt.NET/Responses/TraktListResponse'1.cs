namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>A Trakt list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktListResponse<TResponseContentType> : TraktResponse<IEnumerable<TResponseContentType>>, ITraktListResponse<TResponseContentType>, IEquatable<TraktListResponse<TResponseContentType>>
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

        /// <summary>Gets the enumerator for the list in this response instance.</summary>
        /// <returns>An enumerator for the list in this response instance.</returns>
        public IEnumerator<TResponseContentType> GetEnumerator() => Value.GetEnumerator();

        /// <summary>Gets the enumerator for the list in this response instance.</summary>
        /// <returns>An enumerator for the list in this response instance.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Enables implicit conversion to <see cref="List{TResponseContentType}" /> for this type.</summary>
        /// <param name="response">The <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be converted to <see cref="List{TResponseContentType}" />.</param>
        public static implicit operator List<TResponseContentType>(TraktListResponse<TResponseContentType> response) => response.Value.ToList();

        /// <summary>Enables implicit conversion to <see cref="TraktListResponse{TResponseContentType}" /> for this type.</summary>
        /// <param name="value">The <see cref="List{TResponseContentType}" /> instance, which will be converted to <see cref="TraktListResponse{TResponseContentType}" />.</param>
        public static implicit operator TraktListResponse<TResponseContentType>(List<TResponseContentType> value)
            => new TraktListResponse<TResponseContentType>
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktListResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
