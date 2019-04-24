namespace TraktNet.Objects.Authentication
{
    using System;

    /// <summary>Represents a Trakt device response.</summary>
    public class TraktDevice : ITraktDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktDevice" /> class.
        /// <para>
        /// Sets <see cref="CreatedAt" /> to the DateTime, when it is initialized.
        /// The instantiated device instance is invalid.
        /// </para>
        /// </summary>
        public TraktDevice() { CreatedAt = DateTime.UtcNow; }

        /// <summary>Gets or sets the actual device code.</summary>
        public string DeviceCode { get; set; }

        /// <summary>Gets or sets the user code.</summary>
        public string UserCode { get; set; }

        /// <summary>Gets or sets the verification URL.</summary>
        public string VerificationUrl { get; set; }

        /// <summary>Gets or sets the seconds, after which this device will expire.</summary>
        public uint ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the interval, at which the access token should be polled.</summary>
        public uint IntervalInSeconds { get; set; }

        /// <summary>Gets the interval in milliseconds, at which the access token should be polled.</summary>
        public uint IntervalInMilliseconds => IntervalInSeconds * 1000;

        /// <summary>
        /// Returns, whether this device is valid.
        /// <para>
        /// A Trakt device is valid, as long as the actual <see cref="DeviceCode" />
        /// is neither null nor empty and as long as this device is not expired.<para />
        /// See also <seealso cref="ExpiresInSeconds" />.<para />
        /// See also <seealso cref="IsExpiredUnused" />.<para />
        /// </para>
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(DeviceCode) && !string.IsNullOrEmpty(UserCode) && !string.IsNullOrEmpty(VerificationUrl) && !IsExpiredUnused && IntervalInSeconds > 0;

        /// <summary>Gets the UTC DateTime, when this device was created.</summary>
        public DateTime CreatedAt { get; }

        /// <summary>Gets, whether this device is expired without actually using it for polling for an access token.</summary>
        public bool IsExpiredUnused => CreatedAt.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow;

        /// <summary>Gets a string representation of the device.</summary>
        /// <returns>A string representation of the device.</returns>
        public override string ToString()
        {
            string value = !string.IsNullOrEmpty(DeviceCode) ? $"{DeviceCode}" : "no valid device code";
            value += IsExpiredUnused ? " (expired unused)" : $" (valid until {CreatedAt.AddSeconds(ExpiresInSeconds)})";
            return value;
        }

        /// <summary>Compares this instance with another <see cref="ITraktDevice" /> instance.</summary>
        /// <param name="other">The other <see cref="ITraktDevice" /> instance, with which this instance will be compared.</param>
        /// <returns>True, if both instances are equal, otherwise false.</returns>
        public bool Equals(ITraktDevice other)
        {
            return other != null
                && other.IsExpiredUnused == IsExpiredUnused
                && other.IsValid == IsValid
                && other.ExpiresInSeconds == ExpiresInSeconds
                && other.IntervalInSeconds == IntervalInSeconds
                && other.IntervalInMilliseconds == IntervalInMilliseconds
                && other.DeviceCode == DeviceCode
                && other.UserCode == UserCode
                && other.VerificationUrl == VerificationUrl;
        }
    }
}