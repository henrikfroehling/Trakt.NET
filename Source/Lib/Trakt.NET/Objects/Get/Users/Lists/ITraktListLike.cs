namespace TraktNet.Objects.Get.Users.Lists
{
    using System;

    /// <summary>Represents a Trakt user list like.</summary>
    public interface ITraktListLike
    {
        /// <summary>Gets or sets the UTC datetime, when the list was liked.</summary>
        DateTime? LikedAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user who liked the list.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUser User { get; set; }
    }
}
