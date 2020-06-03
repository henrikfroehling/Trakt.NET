namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>A Trakt paged list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktPagedResponse<TResponseContentType> : TraktListResponse<TResponseContentType>, ITraktPagedResponse<TResponseContentType>, IEquatable<TraktPagedResponse<TResponseContentType>>
    {
        /// <summary>Gets the page count for this response.</summary>
        public int? PageCount { get; set; }

        /// <summary>Gets the item count per page for this response.</summary>
        public int? ItemCount { get; set; }

        /// <summary>
        /// Compares this instance with another <see cref="TraktPagedResponse{TResponseContentType}" /> instance.
        /// </summary>
        /// <param name="other">Another <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be compared with this instance.</param>
        /// <returns>True, of both instances are equal, otherwise false.</returns>
        public bool Equals(TraktPagedResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.Page == Page
                && other.Limit == Limit
                && other.PageCount == PageCount
                && other.ItemCount == ItemCount;
        }

        /// <summary>Enables implicit conversion to <see cref="List{TResponseContentType}" /> for this type.</summary>
        /// <param name="response">The <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be converted to <see cref="List{TResponseContentType}" />.</param>
        public static explicit operator List<TResponseContentType>(TraktPagedResponse<TResponseContentType> response) => response.Value.ToList();

        /// <summary>Enables implicit conversion to <see cref="TraktPagedResponse{TResponseContentType}" /> for this type.</summary>
        /// <param name="value">The <see cref="List{TResponseContentType}" /> instance, which will be converted to <see cref="TraktPagedResponse{TResponseContentType}" />.</param>
        public static implicit operator TraktPagedResponse<TResponseContentType>(List<TResponseContentType> value)
            => new TraktPagedResponse<TResponseContentType>
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
