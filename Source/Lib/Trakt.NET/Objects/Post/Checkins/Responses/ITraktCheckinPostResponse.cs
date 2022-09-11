namespace TraktNet.Objects.Post.Checkins.Responses
{
    using Objects.Basic;
    using System;

    public interface ITraktCheckinPostResponse
    {
        /// <summary>Gets or sets the history id for the checkin response.</summary>
        ulong Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the checked in movie or episode was watched.</summary>
        DateTime? WatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the checkin response.
        /// See also <seealso cref="ITraktConnections" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktConnections Sharing { get; set; }
    }
}
