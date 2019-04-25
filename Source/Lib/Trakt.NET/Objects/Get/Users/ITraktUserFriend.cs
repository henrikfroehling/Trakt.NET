namespace TraktNet.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user friend.</summary>
    public interface ITraktUserFriend : ITraktUser
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        DateTime? FriendsAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user friend.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUser User { get; set; }
    }
}
