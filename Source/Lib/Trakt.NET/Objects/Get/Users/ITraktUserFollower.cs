namespace TraktNet.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user follower.</summary>
    public interface ITraktUserFollower : ITraktUser
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        DateTime? FollowedAt { get; set; }

        /// <summary>
        /// Gets or sets the following / followed Trakt user.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUser User { get; set; }
    }
}
