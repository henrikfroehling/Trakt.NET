namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktPagedResponse<TResponseContentType> : TraktListResponse<TResponseContentType>, ITraktPagedResponse<TResponseContentType>, IEquatable<TraktPagedResponse<TResponseContentType>>
    {
        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        public bool Equals(TraktPagedResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.Page == Page
                && other.Limit == Limit
                && other.PageCount == PageCount
                && other.ItemCount == ItemCount;
        }

        public static explicit operator List<TResponseContentType>(TraktPagedResponse<TResponseContentType> response) => response.Value.ToList();

        public static implicit operator TraktPagedResponse<TResponseContentType>(List<TResponseContentType> value)
            => new TraktPagedResponse<TResponseContentType>
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
