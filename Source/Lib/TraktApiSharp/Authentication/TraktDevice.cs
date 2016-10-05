namespace TraktApiSharp.Authentication
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Represents a Trakt device response.
    /// <para>
    /// See also <seealso cref="TraktDeviceAuth.GenerateDeviceAsync()" />,
    /// <seealso cref="TraktDeviceAuth.GenerateDeviceAsync(string)" />.<para />
    /// See <a href="http://docs.trakt.apiary.io/#reference/authentication-devices/device-code/generate-new-device-codes">"Trakt API Doc - Devices: Device Code"</a> for more information.
    /// </para>
    /// </summary>
    public class TraktDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktDevice" /> class.
        /// <para>
        /// Sets <see cref="Created" /> to the DateTime, when it is initialized.
        /// The instantiated device instance is invalid.
        /// </para>
        /// </summary>
        public TraktDevice() { Created = DateTime.UtcNow; }

        /// <summary>Gets or sets the actual device code.</summary>
        [JsonProperty(PropertyName = "device_code")]
        public string DeviceCode { get; set; }

        /// <summary>Gets or sets the user code.</summary>
        [JsonProperty(PropertyName = "user_code")]
        public string UserCode { get; set; }

        /// <summary>Gets or sets the verification URL.</summary>
        [JsonProperty(PropertyName = "verification_url")]
        public string VerificationUrl { get; set; }

        /// <summary>Gets or sets the seconds, after which this device will expire.</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresInSeconds { get; set; }

        /// <summary>Gets or sets the interval, at which the access token should be polled.</summary>
        [JsonProperty(PropertyName = "interval")]
        public int IntervalInSeconds { get; set; }

        /// <summary>
        /// Returns, whether this device is valid.
        /// <para>
        /// A Trakt device is valid, as long as the actual <see cref="DeviceCode" />
        /// is neither null nor empty and as long as this device is not expired.<para />
        /// See also <seealso cref="ExpiresInSeconds" />.<para />
        /// See also <seealso cref="IsExpiredUnused" />.<para />
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(DeviceCode) && !IsExpiredUnused;

        /// <summary>Gets the UTC DateTime, when this device was created.</summary>
        [JsonIgnore]
        public DateTime Created { get; internal set; }

        /// <summary>Gets, whether this device is expired without actually using it for polling for an access token.</summary>
        [JsonIgnore]
        public bool IsExpiredUnused => Created.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow;
    }
}
