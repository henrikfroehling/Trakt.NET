namespace TraktNet.Responses
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktListResponse<TResponseContentType> : TraktResponse<IEnumerable<TResponseContentType>>, ITraktListResponse<TResponseContentType>, IEquatable<TraktListResponse<TResponseContentType>>
    {
        public bool Equals(TraktListResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other);
        }

        public IEnumerator<TResponseContentType> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator List<TResponseContentType>(TraktListResponse<TResponseContentType> response) => response.Value.ToList();

        public static implicit operator TraktListResponse<TResponseContentType>(List<TResponseContentType> value)
            => new TraktListResponse<TResponseContentType>
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        public static implicit operator bool(TraktListResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;
    }
}
