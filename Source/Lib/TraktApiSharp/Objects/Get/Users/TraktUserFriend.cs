namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt user friend.</summary>
    public class TraktUserFriend
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        [JsonProperty(PropertyName = "friends_at")]
        public DateTime? FriendsAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user friend.
        /// See also <seealso cref="TraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
