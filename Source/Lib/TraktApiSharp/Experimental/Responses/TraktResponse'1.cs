namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces;
    using System;

    public class TraktResponse<TContentType> : TraktNoContentResponse, ITraktResponse<TContentType>, IEquatable<TraktResponse<TContentType>>
    {
        public bool HasValue { get; set; }

        public TContentType Value { get; set; }

        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TrendingUserCount { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public bool? IsPrivateUser { get; set; }

        public bool Equals(TraktResponse<TContentType> other)
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

        public static implicit operator TContentType(TraktResponse<TContentType> response) => response.Value;

        public static implicit operator TraktResponse<TContentType>(TContentType value) => new TraktResponse<TContentType> { Value = value };
    }
}
