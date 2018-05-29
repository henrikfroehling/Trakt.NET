namespace TraktApiSharp.Objects.Get.Users
{
    using System;

    /// <summary>Represents a Trakt user follow request.</summary>
    public class TraktUserFollowRequest : ITraktUserFollowRequest
    {
        /// <summary>Gets or sets the id of the follow request.</summary>
        public uint Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the request was made.</summary>
        public DateTime? RequestedAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user, who is requesting.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }
    }
}
