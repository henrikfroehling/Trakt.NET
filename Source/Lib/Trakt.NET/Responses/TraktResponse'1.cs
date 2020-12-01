namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt response with content of type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type.</typeparam>
    public class TraktResponse<TResponseContentType> : TraktNoContentResponse, ITraktResponse<TResponseContentType>, IEquatable<TraktResponse<TResponseContentType>>
    {
        /// <summary>Gets, whether this response has a content value set.</summary>
        public bool HasValue { get; set; }

        /// <summary>Gets the set content value of this response.</summary>
        public TResponseContentType Value { get; set; }

        /// <summary>Gets the value of the set "sort-by" response header. Might not be set.</summary>
        public string SortBy { get; set; }

        /// <summary>Gets the value of the set "sort-how" response header. Might not be set.</summary>
        public string SortHow { get; set; }

        /// <summary>Gets the value of the set "applied-sort-by" response header. Might not be set.</summary>
        public string AppliedSortBy { get; set; }

        /// <summary>Gets the value of the set "applied-sort-how" response header. Might not be set.</summary>
        public string AppliedSortHow { get; set; }

        /// <summary>Gets the value of the set "start-date" response header. Might not be set.</summary>
        public DateTime? StartDate { get; set; }

        /// <summary>Gets the value of the set "end-date" response header. Might not be set.</summary>
        public DateTime? EndDate { get; set; }

        /// <summary>Gets the value of the set "trending-user-count" response header. Might not be set.</summary>
        public int? TrendingUserCount { get; set; }

        /// <summary>Gets the value of the set "page" response header. Might not be set.</summary>
        public uint? Page { get; set; }

        /// <summary>Gets the value of the set "limit" response header. Might not be set.</summary>
        public uint? Limit { get; set; }

        /// <summary>Gets the value of the set "is-private-user" response header. Might not be set.</summary>
        public bool? IsPrivateUser { get; set; }

        /// <summary>Gets the value of the set "item-id" response header. Might not be set.</summary>
        public int? ItemId { get; set; }

        /// <summary>Gets the value of the set "item-type" response header. Might not be set.</summary>
        public string ItemType { get; set; }

        /// <summary>Gets the value of the set "RateLimit" response header. Might not be set.</summary>
        public string RateLimit { get; set; }

        /// <summary>Gets the value of the set "Retry-After" response header. Might not be set.</summary>
        public int? RetryAfter { get; set; }

        /// <summary>
        /// Compares this instance with another <see cref="TraktResponse{TResponseContentType}" /> instance.
        /// </summary>
        /// <param name="other">Another <see cref="TraktResponse{TResponseContentType}" /> instance, which will be compared with this instance.</param>
        /// <returns>True, of both instances are equal, otherwise false.</returns>
        public bool Equals(TraktResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.HasValue == HasValue
                && other.Value.Equals(Value)
                && other.SortBy == SortBy
                && other.SortHow == SortHow
                && other.StartDate == StartDate
                && other.EndDate == EndDate
                && other.TrendingUserCount == TrendingUserCount
                && other.Page == Page
                && other.Limit == Limit
                && other.IsPrivateUser == IsPrivateUser
                && other.ItemId == ItemId
                && other.ItemType == ItemType
                && other.RateLimit == RateLimit
                && other.RetryAfter == RetryAfter;
        }

        /// <summary>Enables implicit conversion to <typeparamref name="TResponseContentType" /> for this type.</summary>
        /// <param name="response">The <see cref="TraktResponse{TResponseContentType}" /> instance, which will be converted to <typeparamref name="TResponseContentType" />.</param>
        public static implicit operator TResponseContentType(TraktResponse<TResponseContentType> response) => response.Value;

        /// <summary>Enables implicit conversion to <see cref="TraktResponse{TResponseContentType}" /> for this type.</summary>
        /// <param name="value">The <typeparamref name="TResponseContentType" /> instance, which will be converted to <see cref="TraktResponse{TResponseContentType}" />.</param>
        public static implicit operator TraktResponse<TResponseContentType>(TResponseContentType value)
            => new TraktResponse<TResponseContentType>
            {
                Value = value,
                HasValue = !EqualityComparer<TResponseContentType>.Default.Equals(value, default),
                IsSuccess = !EqualityComparer<TResponseContentType>.Default.Equals(value, default)
            };

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
