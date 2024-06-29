namespace TraktNET
{
    /// <summary>A Trakt paged list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktPagedResponse<TResponseContentType> : TraktListResponse<TResponseContentType>
    {
        public override bool Equals(object? obj) => Equals(obj as TraktPagedResponse<TResponseContentType>);

        public bool Equals(TraktPagedResponse<TResponseContentType>? other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception && HasValue == other.HasValue
            && (Value?.Equals(other.Value) ?? false);

        public bool Equals(TraktPagedResponse<TResponseContentType>? x, TraktPagedResponse<TResponseContentType>? y) => x?.Equals(y) ?? false;

        public int GetHashCode(TraktPagedResponse<TResponseContentType>? obj) => obj?.GetHashCode() ?? 0;

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response)
            => response.IsSuccess && response.HasValue;
    }
}
