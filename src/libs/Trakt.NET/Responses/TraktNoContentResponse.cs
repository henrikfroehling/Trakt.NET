namespace TraktNET
{
    /// <summary>A Trakt response with no content.</summary>
    public class TraktNoContentResponse : IEquatable<TraktNoContentResponse>, IEqualityComparer<TraktNoContentResponse>
    {
        /// <summary>Gets, whether the request for this response was successful.</summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>If <see cref="IsSuccess" /> is false this contains the thrown exception.</summary>
        public Exception? Exception { get; internal set; }

        public override bool Equals(object? obj) => Equals(obj as TraktNoContentResponse);

        public bool Equals(TraktNoContentResponse? other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception;

        public bool Equals(TraktNoContentResponse? x, TraktNoContentResponse? y) => x?.Equals(y) ?? false;

        public int GetHashCode(TraktNoContentResponse? obj) => obj?.GetHashCode() ?? 0;

        public override int GetHashCode() => HashHelpers.Combine(IsSuccess.GetHashCode(), Exception?.GetHashCode() ?? 0);

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktNoContentResponse" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktNoContentResponse response) => response.IsSuccess;
    }
}
