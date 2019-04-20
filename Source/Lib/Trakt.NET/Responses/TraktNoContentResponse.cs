namespace TraktNet.Responses
{
    using Core;
    using Interfaces;
    using System;

    /// <summary>A Trakt response with no content.</summary>
    public class TraktNoContentResponse : ITraktNoContentResponse, IEquatable<TraktNoContentResponse>
    {
        /// <summary>Gets, whether the request for this response was successful.</summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// If <see cref="IsSuccess" /> is false and if <see cref="TraktConfiguration.ThrowResponseExceptions" /> is set to false,
        /// this contains the thrown exception.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Compares this instance with another <see cref="TraktNoContentResponse" /> instance.
        /// </summary>
        /// <param name="other">Another <see cref="TraktNoContentResponse" /> instance, which will be compared with this instance.</param>
        /// <returns>True, of both instances are equal, otherwise false.</returns>
        public bool Equals(TraktNoContentResponse other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception;

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktNoContentResponse" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktNoContentResponse response) => response.IsSuccess;
    }
}
