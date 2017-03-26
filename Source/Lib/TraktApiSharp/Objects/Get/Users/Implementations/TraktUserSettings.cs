namespace TraktApiSharp.Objects.Get.Users.Implementations
{
    using Basic;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic.Implementations;

    /// <summary>Represents Trakt user settings.</summary>
    public class TraktUserSettings : ITraktUserSettings
    {
        /// <summary>
        /// Gets or sets the Trakt user for this settings.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public ITraktUser User { get; set; }

        /// <summary>
        /// Gets or sets the account settings.
        /// See also <seealso cref="ITraktAccountSettings" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "account")]
        public ITraktAccountSettings Account { get; set; }

        /// <summary>
        /// Gets or sets the social media connection settings.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "connections")]
        public ITraktSharing Connections { get; set; }

        /// <summary>
        /// Gets or sets the social media sharing text settings.
        /// See also <seealso cref="ITraktSharingText" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing_text")]
        public ITraktSharingText SharingText { get; set; }
    }
}
