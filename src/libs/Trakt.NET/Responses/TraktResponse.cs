namespace TraktNET
{
    /// <summary>A Trakt response with content of type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type.</typeparam>
    public class TraktResponse<TResponseContentType> : TraktNoContentResponse
    {
        /// <summary>Gets, whether this response has a content value set.</summary>
        public bool HasValue => Value != null;

        /// <summary>Gets the set content value of this response.</summary>
        public TResponseContentType? Value { get; internal set; }

        // TODO Add header value properties

        public override bool Equals(object? obj) => Equals(obj as TraktResponse<TResponseContentType>);

        public bool Equals(TraktResponse<TResponseContentType>? other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception && HasValue == other.HasValue
            && (Value?.Equals(other.Value) ?? false);

        public bool Equals(TraktResponse<TResponseContentType>? x, TraktResponse<TResponseContentType>? y) => x?.Equals(y) ?? false;

        public int GetHashCode(TraktResponse<TResponseContentType>? obj) => obj?.GetHashCode() ?? 0;

        public override int GetHashCode()
        {
            int hashCode = IsSuccess.GetHashCode();
            hashCode = HashHelpers.Combine(hashCode, Exception?.GetHashCode() ?? 0);
            hashCode = HashHelpers.Combine(hashCode, HasValue.GetHashCode());
            return HashHelpers.Combine(hashCode, Value?.GetHashCode() ?? 0);
        }

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktResponse<TResponseContentType> response)
            => response.IsSuccess && response.HasValue;
    }
}
