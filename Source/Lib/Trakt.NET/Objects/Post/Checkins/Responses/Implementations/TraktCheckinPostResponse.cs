namespace TraktNet.Objects.Post.Checkins.Responses
{
    using Basic;
    using System;

    public abstract class TraktCheckinPostResponse : ITraktCheckinPostResponse
    {
        /// <summary>Gets or sets the history id for the checkin response.</summary>
        public ulong Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the checked in movie or episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the checkin response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSharing Sharing { get; set; }
    }
}
