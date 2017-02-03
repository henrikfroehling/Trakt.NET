namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktPaginationResponse<TContentType> : TraktListResponse<TContentType>, ITraktPaginationResponse<TContentType>, IEquatable<TraktPaginationResponse<TContentType>>
    {
        public int? Page { get; set; }

        public int? Limit { get; set; }

        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        public bool Equals(TraktPaginationResponse<TContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.Page == Page
                && other.Limit == Limit
                && other.PageCount == PageCount
                && other.ItemCount == ItemCount;
        }

        public static explicit operator List<TContentType>(TraktPaginationResponse<TContentType> response) => response.Value.ToList();

        public static implicit operator TraktPaginationResponse<TContentType>(List<TContentType> value) => new TraktPaginationResponse<TContentType> { Value = value };
    }
}
