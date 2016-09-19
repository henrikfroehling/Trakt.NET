namespace TraktApiSharp.Requests.Base
{
    using Exceptions;
    using System.Collections.Generic;

    public class TraktPaginationResponse<TItem> : TraktResponse<List<TItem>>, ITraktPaginationResponseHeaders
    {
        public int? ItemCount { get; set; }

        public int? Limit { get; set; }

        public int? Page { get; set; }

        public int? PageCount { get; set; }

        public TraktPaginationResponse(List<TItem> value) : base(value) { }

        public TraktPaginationResponse(TraktException exception) : base(exception) { }

        public static explicit operator List<TItem>(TraktPaginationResponse<TItem> response) => response.Value;

        public static implicit operator TraktPaginationResponse<TItem>(List<TItem> value) => new TraktPaginationResponse<TItem>(value);

        public override bool Equals(object obj)
        {
            if (obj is TraktPaginationResponse<TItem>)
                return Equals((TraktPaginationResponse<TItem>)obj);

            return false;
        }

        public bool Equals(TraktPaginationResponse<TItem> other)
        {
            if (HasValue && other.HasValue)
                return Equals(Value, other.Value);

            return HasValue == other.HasValue;
        }

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : base.GetHashCode();
    }
}
