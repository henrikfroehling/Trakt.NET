namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktPagedResponse<TContentType> : TraktListResponse<TContentType>, ITraktPagedResponse<TContentType>, IEquatable<TraktPagedResponse<TContentType>>
    {
        public int? Page { get; set; }

        public int? Limit { get; set; }

        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        public bool Equals(TraktPagedResponse<TContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.Page == Page
                && other.Limit == Limit
                && other.PageCount == PageCount
                && other.ItemCount == ItemCount;
        }

        public static explicit operator List<TContentType>(TraktPagedResponse<TContentType> response) => response.Value.ToList();

        public static implicit operator TraktPagedResponse<TContentType>(List<TContentType> value) => new TraktPagedResponse<TContentType> { Value = value };
    }
}
