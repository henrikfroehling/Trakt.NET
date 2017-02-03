namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces.Base;
    using System;

    public class TraktResponse<TContentType> : TraktNoContentResponse, ITraktResponse<TContentType>, IEquatable<TraktResponse<TContentType>>
    {
        public bool HasValue { get; set; }

        public TContentType Value { get; set; }

        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public int? UserCount { get; set; }

        public bool Equals(TraktResponse<TContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.HasValue == HasValue
                && other.Value.Equals(Value)
                && other.SortBy == SortBy
                && other.SortHow == SortHow
                && other.UserCount == UserCount;
        }

        public static implicit operator TContentType(TraktResponse<TContentType> response) => response.Value;

        public static implicit operator TraktResponse<TContentType>(TContentType value) => new TraktResponse<TContentType> { Value = value };
    }
}
