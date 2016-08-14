namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    /// <summary>Represents Trakt user settings.</summary>
    public class TraktUserSettings
    {
        /// <summary>
        /// Gets or sets the Trakt user for this settings.
        /// See also <seealso cref="TraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }

        /// <summary>
        /// Gets or sets the account settings.
        /// See also <seealso cref="TraktAccountSettings" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "account")]
        [Nullable]
        public TraktAccountSettings Account { get; set; }

        /// <summary>
        /// Gets or sets the social media connection settings.
        /// See also <seealso cref="TraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "connections")]
        [Nullable]
        public TraktSharing Connections { get; set; }

        /// <summary>
        /// Gets or sets the social media sharing text settings.
        /// See also <seealso cref="TraktSharingText" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing_text")]
        [Nullable]
        public TraktSharingText SharingText { get; set; }
    }
}
