using System.Collections;

namespace TraktNET
{
    /// <summary>A Trakt list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktListResponse<TResponseContentType> : TraktResponse<IReadOnlyList<TResponseContentType>>, IReadOnlyList<TResponseContentType>
    {
        public override bool Equals(object? obj) => Equals(obj as TraktListResponse<TResponseContentType>);

        public bool Equals(TraktListResponse<TResponseContentType>? other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception && HasValue == other.HasValue
            && (Value?.Equals(other.Value) ?? false);

        public bool Equals(TraktListResponse<TResponseContentType>? x, TraktListResponse<TResponseContentType>? y) => x?.Equals(y) ?? false;

        public int GetHashCode(TraktListResponse<TResponseContentType>? obj) => obj?.GetHashCode() ?? 0;

        public override int GetHashCode() => base.GetHashCode();

        public int Count => Value?.Count ?? 0;

        public TResponseContentType this[int index]
            => Value != null ? Value[index] : throw new InvalidOperationException("Invalid access to non existing list.");

        public IEnumerator<TResponseContentType> GetEnumerator()
            => Value != null ? Value.GetEnumerator() : throw new InvalidOperationException("Invalid access to non existing list.");

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktListResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktListResponse<TResponseContentType> response)
            => response.IsSuccess && response.HasValue;
    }
}
