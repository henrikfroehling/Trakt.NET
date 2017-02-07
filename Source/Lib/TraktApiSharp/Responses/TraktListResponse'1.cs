namespace TraktApiSharp.Responses
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktListResponse<TContentType> : TraktResponse<IEnumerable<TContentType>>, ITraktListResponse<TContentType>, IEquatable<TraktListResponse<TContentType>>
    {
        public bool Equals(TraktListResponse<TContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other);
        }

        public IEnumerator<TContentType> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator List<TContentType>(TraktListResponse<TContentType> response) => response.Value.ToList();

        public static implicit operator TraktListResponse<TContentType>(List<TContentType> value) => new TraktListResponse<TContentType> { Value = value, HasValue = value != null, IsSuccess = value != null };

        public static implicit operator bool(TraktListResponse<TContentType> response) => response.IsSuccess && response.HasValue;
    }
}
