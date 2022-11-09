﻿namespace TraktNet.Objects.Get.Users
{
    using Basic;

    /// <summary>Represents Trakt user settings.</summary>
    public class TraktUserSettings : ITraktUserSettings
    {
        /// <summary>
        /// Gets or sets the Trakt user for this settings.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }

        /// <summary>
        /// Gets or sets the account settings.
        /// See also <seealso cref="ITraktAccountSettings" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktAccountSettings Account { get; set; }

        /// <summary>
        /// Gets or sets the social media connection settings.
        /// See also <seealso cref="ITraktConnections" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktConnections Connections { get; set; }

        /// <summary>
        /// Gets or sets the social media sharing text settings.
        /// See also <seealso cref="ITraktSharingText" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSharingText SharingText { get; set; }

        /// <summary>
        /// Gets or sets the user's limits.
        /// See also <seealso cref="ITraktUserLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserLimits Limits { get; set; }
    }
}
