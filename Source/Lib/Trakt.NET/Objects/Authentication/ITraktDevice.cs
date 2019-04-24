namespace TraktNet.Objects.Authentication
{
    using System;

    /// <summary>Represents a Trakt device response.</summary>
    public interface ITraktDevice : IEquatable<ITraktDevice>
    {
        /// <summary>Gets or sets the actual device code.</summary>
        string DeviceCode { get; set; }

        /// <summary>Gets or sets the user code.</summary>
        string UserCode { get; set; }

        /// <summary>Gets or sets the verification URL.</summary>
        string VerificationUrl { get; set; }

        /// <summary>Gets or sets the seconds, after which this device will expire.</summary>
        uint ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the interval, at which the access token should be polled.</summary>
        uint IntervalInSeconds { get; set; }

        /// <summary>Gets the interval in milliseconds, at which the access token should be polled.</summary>
        uint IntervalInMilliseconds { get; }

        /// <summary>
        /// Returns, whether this device is valid.
        /// <para>
        /// A Trakt device is valid, as long as the actual <see cref="DeviceCode" />
        /// is neither null nor empty and as long as this device is not expired.<para />
        /// See also <seealso cref="ExpiresInSeconds" />.<para />
        /// See also <seealso cref="IsExpiredUnused" />.<para />
        /// </para>
        /// </summary>
        bool IsValid { get; }

        /// <summary>Gets the UTC DateTime, when this device was created.</summary>
        DateTime CreatedAt { get; }

        /// <summary>Gets, whether this device is expired without actually using it for polling for an access token.</summary>
        bool IsExpiredUnused { get; }

        /// <summary>Gets a string representation of the device.</summary>
        /// <returns>A string representation of the device.</returns>
        string ToString();
    }
}
