namespace TraktNet.Objects.Get.Users
{
    using Basic;

    /// <summary>Represents Trakt user settings.</summary>
    public interface ITraktUserSettings
    {
        /// <summary>
        /// Gets or sets the Trakt user for this settings.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUser User { get; set; }

        /// <summary>
        /// Gets or sets the account settings.
        /// See also <seealso cref="ITraktAccountSettings" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktAccountSettings Account { get; set; }

        /// <summary>
        /// Gets or sets the social media connection settings.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSharing Connections { get; set; }

        /// <summary>
        /// Gets or sets the social media sharing text settings.
        /// See also <seealso cref="ITraktSharingText" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSharingText SharingText { get; set; }

        /// <summary>
        /// Gets or sets the user's limits.
        /// See also <seealso cref="ITraktUserLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserLimits Limits { get; set; }
    }
}
