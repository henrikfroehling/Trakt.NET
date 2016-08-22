namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt user follower.</summary>
    public class TraktUserFollower
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        [JsonProperty(PropertyName = "followed_at")]
        public DateTime? FollowedAt { get; set; }

        /// <summary>
        /// Gets or sets the following / followed Trakt user.
        /// See also <seealso cref="TraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
