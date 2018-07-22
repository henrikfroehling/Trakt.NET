namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class TraktResponse<TResponseContentType> : TraktNoContentResponse, ITraktResponse<TResponseContentType>, IEquatable<TraktResponse<TResponseContentType>>
    {
        public bool HasValue { get; set; }

        public TResponseContentType Value { get; set; }

        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TrendingUserCount { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public bool? IsPrivateUser { get; set; }

        public int? XItemId { get; set; }

        public string XItemType { get; set; }

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
                && other.IsPrivateUser == IsPrivateUser;
        }

        public static implicit operator TResponseContentType(TraktResponse<TResponseContentType> response) => response.Value;

        public static implicit operator TraktResponse<TResponseContentType>(TResponseContentType value)
            => new TraktResponse<TResponseContentType>
            {
                Value = value,
                HasValue = !EqualityComparer<TResponseContentType>.Default.Equals(value, default),
                IsSuccess = !EqualityComparer<TResponseContentType>.Default.Equals(value, default)
            };

        public static implicit operator bool(TraktResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
